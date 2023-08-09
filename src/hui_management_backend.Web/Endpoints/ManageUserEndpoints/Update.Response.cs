using hui_management_backend.Web.Endpoints.DTOs;
namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class UpdateResponse
{
  public SubUserRecord SubUser { set; get; }

  public UpdateResponse(SubUserRecord subUser)
  {
    this.SubUser = subUser;
  }
}
