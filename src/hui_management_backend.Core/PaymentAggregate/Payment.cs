
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.PaymentAggregate;
public class Payment : EntityBase, IAggregateRoot
{
  public required User Owner { get; set;  } 
  public int OwnerId { get;  }
  public required DateTimeOffset CreateAt { get; set; }

  public required double Amount { get; set; }
  public double Remain => _paymentTransactions.Sum(pt => pt.Amount) - Amount;

  public required PaymentType Type { get; set; }
  public required PaymentStatus Status { get; set; } 

  private readonly List<PaymentTransaction> _paymentTransactions = new List<PaymentTransaction>();
  public IEnumerable<PaymentTransaction> PaymentTransactions => _paymentTransactions.AsReadOnly();


}
