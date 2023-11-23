using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundAddEmergencySessionRequest
{
  public const string Route = "/funds/{fundId}/sessions/add-emergency";

  [FromRoute(Name = "fundId")]
  public int fundId { get; set; }

  [FromBody]
  public FundAddEmergencySessionRequestBody body { get; set; } = null!;
}
