

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

    List<Payment> payments = new();
     
    foreach(NormalSessionDetail sessionDetail in notification.fundSession.normalSessionDetails)
    {

      var normalPayment = await _getPaymentService.GetPaymentByDateAndOwnerId(DateTimeOffset.Now, sessionDetail.fundMember.User);

      normalPayment.AddBill(new FundBill
      {
        fromSession = notification.fundSession,
        fromSessionDetail = sessionDetail,
        fromFund = notification.fund
      });


      payments.Add(normalPayment);
    }

    await _paymentRepository.UpdateRangeAsync(payments);

  }
}
