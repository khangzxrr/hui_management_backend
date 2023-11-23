
using hui_management_backend.Core.FundAggregate.Events;
using hui_management_backend.Core.PaymentAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using MediatR;

namespace hui_management_backend.Core.PaymentAggregate.Handlers;
public class FundSessionDeletedEventHandler : INotificationHandler<FundSessionDeleteEvent>
{

  private readonly IRepository<Payment> _paymentRepository;

  public FundSessionDeletedEventHandler(IRepository<Payment> paymentRepository)
  {
    _paymentRepository = paymentRepository;
  }
  public async Task Handle(FundSessionDeleteEvent notification, CancellationToken cancellationToken)
  {
    var paymentSpec = new PaymentByFundSessionIdSpec(notification.fundSession.Id);

    var payments = await _paymentRepository.ListAsync(paymentSpec);

    foreach (var payment in payments)
    {
      payment.RemoveAllFundBillWithSessionId(notification.fundSession.Id);

      //lets remove payment if totalCost == 0 ?
      //bill == 0 is not making sense
      if (payment.TotalCost() == 0)
      {
        await _paymentRepository.DeleteAsync(payment);  
      } else
      {
        await _paymentRepository.UpdateAsync(payment);
      }
    }
  }
}
