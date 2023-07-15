
using Ardalis.SmartEnum;

namespace hui_management_backend.Core.PaymentAggregate;
public class PaymentType : SmartEnum<PaymentType> 
{

  public static PaymentType TransferToOwner = new(nameof(TransferToOwner), 0);
  public static PaymentType TransferToMember = new(nameof(TransferToMember), 1);
  protected PaymentType(string name, int value) : base(name, value) { }
}
