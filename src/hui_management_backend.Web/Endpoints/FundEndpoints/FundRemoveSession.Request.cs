using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundRemoveSessionRequest
{
  public const string Route = "/funds/{fundId}/sessions/{sessionId}";

  [FromRoute]
  public int fundId { get; set; }
  [FromRoute]
  public int sessionId { get; set; }
}
