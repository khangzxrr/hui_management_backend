
using Ardalis.GuardClauses;
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate;
public class TakenSessionDetail : EntityBase
{
  public int sessionId { get; set; }
  public FundMember fundMember { get; set; } = null!;
  public double predictedPrice { get; private set; }
  public double fundAmount { get; private set; }
  public double remainPrice { get; private set; }
  public double serviceCost { get; private set; }

  public void SetFundMember(FundMember fundMember)
  {
    this.fundMember = Guard.Against.Null(fundMember);
  }

  public TakenSessionDetail(double predictedPrice, double fundAmount, double remainPrice, double serviceCost)
  {
    this.predictedPrice = predictedPrice;
    this.fundAmount = fundAmount;
    this.remainPrice = remainPrice;
    this.serviceCost = serviceCost;
  }
}
