
using hui_management_backend.Core.UserAggregate;

namespace hui_management_backend.Web.Interfaces;

public interface ITokenService
{
  public string GenerateToken(User user);
}
