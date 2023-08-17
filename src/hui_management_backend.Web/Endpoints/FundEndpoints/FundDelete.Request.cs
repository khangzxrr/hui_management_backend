using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundDeleteRequest
{
  public const string Route = "/funds/{fundId}";

  [FromRoute]
  public int fundId { get; set; }
}
