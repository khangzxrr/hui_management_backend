

using hui_management_backend.Web.Endpoints.DTOs;
using hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public class ReportAllResponse
{
  public IEnumerable<UserRecord> Users { get; set; }

  //generate constructor
  public ReportAllResponse(IEnumerable<UserRecord> users)
  {
    Users = users;
  }

}
