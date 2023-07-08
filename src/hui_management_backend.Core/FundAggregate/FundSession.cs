
using Ardalis.GuardClauses;
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate;
public class FundSession : EntityBase
{

  public FundMember FundMember { get; set; } = null!;

  public DateTimeOffset TakenDate { get; private set; }

  public double PredictPrice { get; private set; }
  public double FundAmount { get; private set;}
  public double RemainPrice { get; private set; }
  public double OwnerCost { get; private set; }


  public void SetFundMember(FundMember fundMember)
  {
    FundMember = Guard.Against.Null(fundMember);
  }

  public FundSession(double predictPrice, double fundAmount, double ownerCost, double remainPrice)
  {
    
    PredictPrice = Guard.Against.NegativeOrZero(predictPrice);
    FundAmount = Guard.Against.NegativeOrZero(fundAmount);
    RemainPrice = Guard.Against.NegativeOrZero(remainPrice);
    OwnerCost = Guard.Against.NegativeOrZero(ownerCost);

    TakenDate = DateTimeOffset.UtcNow;
  }

}
