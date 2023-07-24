

using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Events;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.SharedKernel.Interfaces;
using MediatR;

namespace hui_management_backend.Core.PaymentAggregate.Handlers;
public class NewFundSessionAddedHandler : INotificationHandler<NewFundSessionAddedEvent>
{

  private readonly IRepository<Payment> _paymentRepository;
  private readonly IGetPaymentService _getPaymentService;
  
  public NewFundSessionAddedHandler(IRepository<Payment> repository, IGetPaymentService getPaymentService)
  {
    _paymentRepository = repository;
    _getPaymentService = getPaymentService;
  }

  public async Task Handle(NewFundSessionAddedEvent notification, CancellationToken cancellationToken)
  {

    List<Payment> normalPayments = new();
     
    foreach(NormalSessionDetail normalSessionDetail in notification.fundSession.normalSessionDetails)
    {
      var normalPayment = await _getPaymentService.GetPaymentByDateAndOwnerId(DateTimeOffset.Now, normalSessionDetail.fundMember.User);

      normalPayment.AddBill(new FundBill
      {
        fromSession = notification.fundSession,
        fromSessionDetail = normalSessionDetail,
        fromFund = notification.fund
      });

      normalPayments.Add(normalPayment);
    }

    await _paymentRepository.UpdateRangeAsync(normalPayments);

  }
}
