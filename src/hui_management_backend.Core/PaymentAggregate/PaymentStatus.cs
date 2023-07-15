
using Ardalis.SmartEnum;

namespace hui_management_backend.Core.PaymentAggregate;
public class PaymentStatus : SmartEnum<PaymentStatus>
{
  public static PaymentStatus Processing = new(nameof(Processing), 0);
  public static PaymentStatus Finish = new(nameof(Finish), 1);
  protected PaymentStatus(string name, int value) : base(name, value) { }
}
