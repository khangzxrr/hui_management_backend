using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate;
public class FundMember: EntityBase
{
  public string NickName { get; set; } = null!;
  public User User { get; set; } = null!;

}
