
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate;
public class NormalSessionDetail : EntityBase
{
  public required double predictedPrice { get; set; }
  public required double fundAmount { get; set; }
  public required double serviceCost { get; set; }


  public required double payCost { get; set; }


  public required NormalSessionType type { get; set; }

  public required FundMember fundMember { get; set; } 
}
