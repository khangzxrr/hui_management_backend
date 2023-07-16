
using Ardalis.GuardClauses;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.PaymentAggregate;
public class FundBill : EntityBase
{
  public required Fund fromFund { get; set; }
  public required double Amount { get; set; }

  public required PaymentType Type { get; set; }
  public required PaymentStatus Status { get; set; }

}
