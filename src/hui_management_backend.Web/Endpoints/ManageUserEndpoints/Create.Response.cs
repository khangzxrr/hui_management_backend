using hui_management_backend.Web.Endpoints.DTOs;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class CreateResponse
{
  public SubUserRecord SubUser { get; set; }

  public CreateResponse(SubUserRecord subUser)
  {
    SubUser = subUser;
  }
}
