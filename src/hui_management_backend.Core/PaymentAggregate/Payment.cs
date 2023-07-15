
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.PaymentAggregate;
public class Payment : EntityBase, IAggregateRoot
{
  public User Owner { get; private set;  } = null!;
  public int OwnerId { get;  }
  public DateTimeOffset CreateAt { get; }

  public double Amount { get; }
  public double Remain => _paymentTransactions.Sum(pt => pt.Amount) - Amount;

  public PaymentStatus Status { get; private set; } = null!;

  private readonly List<PaymentTransaction> _paymentTransactions = new List<PaymentTransaction>();
  public IEnumerable<PaymentTransaction> PaymentTransactions => _paymentTransactions.AsReadOnly();


}
