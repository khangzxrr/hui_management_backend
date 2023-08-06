

using hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public class ReportAllResponse
{
  public IEnumerable<UserReport> Users { get; set; }

  //generate constructor
  public ReportAllResponse(IEnumerable<UserReport> users)
  {
    Users = users;
  }

}
