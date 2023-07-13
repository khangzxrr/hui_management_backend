using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundAddSessionRequest
{
  public const string Route = "/funds/{fundId}/sessions/add";

  [FromRoute(Name = "fundId")]
  public int fundId { get; set; }


  [FromBody]
  public FundAddSessionRequestBody body { get; set; } = null!;
}
