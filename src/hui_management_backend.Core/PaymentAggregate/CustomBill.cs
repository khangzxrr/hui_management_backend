using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.PaymentAggregate;

public class CustomBill : EntityBase
{
  public required string description { get; set; }
  public required double payCost { get; set; }
  public required CustomBillType type { get; set; }
}
