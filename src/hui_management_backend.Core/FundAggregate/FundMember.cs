using Ardalis.GuardClauses;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate;
public class FundMember: EntityBase
{
  public string nickName => subUser.Name + "-" + replicationCount;
  public int replicationCount { get; set; }
  public SubUser subUser { get; set; } = null!;

  public int? finalSettlementForDeadSessionBillId { get; private set; }
  public Payment? finalSettlementForDeadSessionBill { get; private set; }

  public bool hasFinalSettlementForDeadSessionBill => finalSettlementForDeadSessionBill != null;
  public void setFinalSettlementForDeadSessionBill(Payment finalSettlementForDeadSessionBill)
  {
    Guard.Against.Null(finalSettlementForDeadSessionBill);
    this.finalSettlementForDeadSessionBill = finalSettlementForDeadSessionBill;
  }

  public void clearFinalSettlementForDeadSessionBill()
  {
    finalSettlementForDeadSessionBill = null;
  }
}
