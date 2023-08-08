using hui_management_backend.Web.Endpoints.DTOs;
namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class UpdateResponse
{
  public UserRecord user { set; get; }

  public UpdateResponse(UserRecord user)
  {
    this.user = user;
  }
}
