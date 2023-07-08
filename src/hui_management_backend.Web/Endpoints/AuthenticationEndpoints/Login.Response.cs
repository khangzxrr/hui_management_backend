namespace hui_management_backend.Web.Endpoints.AuthenticationEndpoints;

public class LoginResponse
{
  public string Token { get; set; } = null!;
  public string Phonenumber { get; set; } = null!;
  public string Email { get; set; } = null!;
  public string Name { get; set; } = null!;
}
