

using hui_management_backend.Web.Endpoints.DTOs;

public class ReportAllResponse
{
  public IEnumerable<SubUserRecord> SubUsers { get; set; }

  //generate constructor
  public ReportAllResponse(IEnumerable<SubUserRecord> subUsers)
  {
    SubUsers = subUsers;
  }

}
