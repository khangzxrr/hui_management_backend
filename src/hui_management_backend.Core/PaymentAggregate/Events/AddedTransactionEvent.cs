using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.PaymentAggregate.Events;
public class AddedTransactionEvent : DomainEventBase
{
  public Payment payment { get; set; }

  public AddedTransactionEvent(Payment payment)
  {
    this.payment = payment;
  }
}
