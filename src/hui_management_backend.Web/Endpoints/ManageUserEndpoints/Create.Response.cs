namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class CreateResponse
{
  public UserRecord User { get; set; }

  public CreateResponse(UserRecord user)
  {
    User = user;
  }
}
