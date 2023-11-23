
using hui_management_backend.Core.FundAggregate.Events;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.SharedKernel.Interfaces;
using MediatR;

namespace hui_management_backend.Core.PaymentAggregate.Handlers;
public class NewEmergencySessionAddedEventHandler : INotificationHandler<NewEmergencySessionAddedEvent>
{

  private readonly IRepository<Payment> _paymentRepository;
  private readonly IGetPaymentService _getPaymentService;

  public NewEmergencySessionAddedEventHandler(IRepository<Payment> paymentRepository, IGetPaymentService getPaymentService)
  {
    _paymentRepository = paymentRepository;
    _getPaymentService = getPaymentService;
  }

  public async Task Handle(NewEmergencySessionAddedEvent notification, CancellationToken cancellationToken)
  {
    List<Payment> newPayments = new();

    foreach(var emergencyTakenSessionDetail in notification.emergencyTakenSessionDetails)
    {
      var userPayment = await _getPaymentService.GetPaymentByDateAndOwnerId(DateTime.UtcNow, emergencyTakenSessionDetail.fundMember.subUser);

      userPayment.RemoveLatestFundBill(notification.fund.Id);

      userPayment.AddBill(new FundBill
      {
        fromFund = notification.fund,
        fromSession = notification.fundSession,
        fromSessionDetail = emergencyTakenSessionDetail,
      }) ;
    }

    await _paymentRepository.UpdateRangeAsync(newPayments);
  }
}
