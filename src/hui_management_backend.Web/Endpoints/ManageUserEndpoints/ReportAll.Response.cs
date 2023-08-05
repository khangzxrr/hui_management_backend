namespace hui_management_backend.Web.Endpoints.ManageUserEndpoints;

public class ReportAllResponse
{
  public IEnumerable<UserReport> Users { get; set; }

  //generate constructor
  public ReportAllResponse(IEnumerable<UserReport> users)
  {
    Users = users;
  }

}
