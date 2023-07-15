
using Ardalis.SmartEnum;
using hui_management_backend.Core.Constants;

namespace hui_management_backend.Core.UserAggregate;
public class RoleName : SmartEnum<RoleName>
{
  public static RoleName User = new(nameof(RoleNameConstants.User), RoleNameConstants.UserValue);
  public static RoleName Owner = new(nameof(RoleNameConstants.Owner), RoleNameConstants.OwnerValue);
  
  public RoleName(string name, int value) : base(name, value) {  }
}
