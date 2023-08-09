using hui_management_backend.Web.Endpoints.DTOs;

namespace hui_management_backend.Web.Endpoints.AuthenticationEndpoints;

public class LoginResponse
{
  public string Token { get; set; } 
  public SubUserRecord SubUser { get; set; }

  public LoginResponse(string token, SubUserRecord subUser)
  {
    Token = token;
    SubUser = subUser;
  }
}
