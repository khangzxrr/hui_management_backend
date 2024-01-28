using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.ManageUserEndpoints;

public class GetWithTotalReportRequest
{
  public const string Route = "/subusers/{id}/reports";

  [FromRoute]
  public int id { get; set; }

}
