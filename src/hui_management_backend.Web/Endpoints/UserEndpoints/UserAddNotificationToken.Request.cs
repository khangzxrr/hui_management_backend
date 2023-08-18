using System.ComponentModel.DataAnnotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class UserAddNotificationTokenRequest
{
  public const string Route = "/users/notificationtokens";

  [Required]
  public string Token { get; set; } = null!;
}
