using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Web.Endpoints.UserEndpoints;

namespace hui_management_backend.Web.Endpoints.AuthenticationEndpoints;

public class LoginResponse
{
  public string Token { get; set; } 
  public UserRecord User { get; set; }

  public LoginResponse(string token, UserRecord user)
  {
    Token = token;
    User = user;
  }
}
