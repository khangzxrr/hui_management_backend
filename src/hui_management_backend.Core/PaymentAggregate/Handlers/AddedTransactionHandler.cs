
using hui_management_backend.Core.PaymentAggregate.Events;
using hui_management_backend.SharedKernel.Interfaces;
using MediatR;

namespace hui_management_backend.Core.PaymentAggregate.Handlers;
public class AddedTransactionHandler : INotificationHandler<AddedTransactionEvent>
{
  private IRepository<Payment> _paymentRepository;

  public AddedTransactionHandler(IRepository<Payment> paymentRepository)
  {
    _paymentRepository = paymentRepository;
  }

  public async Task Handle(AddedTransactionEvent notification, CancellationToken cancellationToken)
  {

    double paidTotal = notification.payment.paymentTransactions.Sum(t => t.Amount);

    if (paidTotal >= Math.Abs(notification.payment.TotalCost()))
    {
      notification.payment.SetStatus(PaymentStatus.Finish);
    } else
    {
      notification.payment.SetStatus(PaymentStatus.Debting);
    }

    await _paymentRepository.UpdateAsync(notification.payment);
  }
}
