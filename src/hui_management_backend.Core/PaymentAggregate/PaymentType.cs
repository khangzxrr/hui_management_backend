
using Ardalis.SmartEnum;

namespace hui_management_backend.Core.PaymentAggregate;
public class PaymentType : SmartEnum<PaymentType> 
{

  public static PaymentType DeadFundSession = new PaymentType(nameof(DeadFundSession), 0);
  public static PaymentType AliveFundSession = new PaymentType(nameof(AliveFundSession), 1);
  public static PaymentType TakenFundSession = new PaymentType(nameof(TakenFundSession), 2);

  protected PaymentType(string name, int value) : base(name, value) { }
}
