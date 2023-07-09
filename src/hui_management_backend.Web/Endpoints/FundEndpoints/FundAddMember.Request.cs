using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundAddMemberRequest
{
  public const string Route = "/funds/{fundId}/members/{memberId}/add";

  [FromRoute]
  public int fundId { get; set; }
  [FromRoute]
  public int memberId { get; set; }

}
