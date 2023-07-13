
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate;
public class NormalSessionDetail : EntityBase
{
  public double payCost { get; set; }

  public FundMember fundMember { get; set; } = null!;
}
