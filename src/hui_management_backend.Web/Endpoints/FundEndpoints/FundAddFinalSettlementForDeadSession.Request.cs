using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundAddFinalSettlementForDeadSessionRequest
{
  public const string Route = "/funds/{fundId}/sessions/final-settlement-for-dead-session/add";

  [FromRoute(Name = "fundId")]
  public int fundId { get; set; }

  [FromBody]
  public FundAddFinalSettlementForDeadSessionRequestBody body { get; set; } = null!;
}
