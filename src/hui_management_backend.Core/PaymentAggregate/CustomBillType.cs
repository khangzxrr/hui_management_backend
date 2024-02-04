using Ardalis.SmartEnum;

namespace hui_management_backend.Core.PaymentAggregate;

public class CustomBillType : SmartEnum<CustomBillType>
{
  public static CustomBillType OwnerPaid = new CustomBillType(nameof(OwnerPaid), 1);
  public static CustomBillType OwnerTake = new CustomBillType(nameof(OwnerTake), 2);
  public static CustomBillType OutsideDebt = new CustomBillType(nameof(OutsideDebt), 3);

  public CustomBillType(string name, int value) : base(name, value)
  {
  }
}
