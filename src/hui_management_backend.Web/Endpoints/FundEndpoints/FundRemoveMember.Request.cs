using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundRemoveMemberRequest
{
  public const string Route = "/funds/{fundId}/members/{memberId}/remove";

  [FromRoute]
  public int fundId { get; set; }
  [FromRoute]
  public int memberId { get; set; }
}
