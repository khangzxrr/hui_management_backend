
using Ardalis.GuardClauses;
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.PaymentAggregate;
public class PaymentTransaction : EntityBase
{
  public string Description { get; private set; } = string.Empty;
  public double Amount { get; private set; } = 0;

  public DateTimeOffset CreateAt { get; private set; }
  public TransactionMethod Method { get; private set; } = null!;

  public PaymentTransaction(string description, double amount, TransactionMethod method)
  {
    Description = description;
    Amount = Guard.Against.Negative(amount);
    Method = Guard.Against.Null(method);

    CreateAt = DateTime.UtcNow;
  }
}
