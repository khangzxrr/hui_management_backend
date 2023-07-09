
using Ardalis.GuardClauses;
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate;
public class FundSessionDetail : EntityBase
{
  public FundMember fundMember { get; set; } = null!;
  public double predictedPrice { get; private set; }
  public double fundAmount { get; private set; }
  public double remainPrice { get; private set; }
  public double ownerCost { get; private set; }

  public void SetFundMember(FundMember fundMember)
  {
    this.fundMember = Guard.Against.Null(fundMember);
  }

  public FundSessionDetail(double predictedPrice, double fundAmount, double remainPrice, double ownerCost)
  {
    this.predictedPrice = predictedPrice;
    this.fundAmount = fundAmount;
    this.remainPrice = remainPrice;
    this.ownerCost = ownerCost;
  }
}
