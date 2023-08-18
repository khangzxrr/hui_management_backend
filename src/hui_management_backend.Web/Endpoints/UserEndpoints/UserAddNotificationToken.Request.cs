namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class UserAddNotificationTokenRequest
{
  public const string Route = "/users/notificationtoken";
  public string Token { get; set; } = null!;
}
