using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate;
public class FundMember: EntityBase
{

  public User User { get; set; } = null!;

}
