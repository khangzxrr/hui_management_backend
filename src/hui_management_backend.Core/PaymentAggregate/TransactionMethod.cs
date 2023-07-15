

using Ardalis.SmartEnum;

namespace hui_management_backend.Core.PaymentAggregate;
public class TransactionMethod : SmartEnum<TransactionMethod>
{
  public static readonly TransactionMethod ByCash = new(nameof(ByCash), 0);
  public static readonly TransactionMethod ByBanking = new(nameof(ByBanking), 1);

  protected TransactionMethod(string name, int id) : base(name, id) { }

}
