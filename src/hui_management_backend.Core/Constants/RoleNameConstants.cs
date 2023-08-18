
namespace hui_management_backend.Core.Constants;
public class RoleNameConstants
{
  public const string Owner = "Owner";
  public const int OwnerValue = 1;

  public const string User = "User";
  public const int UserValue = 0;

  public const string OwnerUser = $"{Owner},{User}";
}
