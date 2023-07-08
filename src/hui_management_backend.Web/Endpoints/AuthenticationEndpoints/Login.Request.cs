using System.ComponentModel.DataAnnotations;

namespace hui_management_backend.Web.Endpoints.AuthenticationEndpoints;

public class LoginRequest
{

  public const string Route = "/login";

  [Required]
  public string phonenumber { get; set; }
  [Required]
  public string password { get; set; }

  public LoginRequest(string phonenumber, string password)
  {
    this.phonenumber = phonenumber;
    this.password = password;
  }
}
