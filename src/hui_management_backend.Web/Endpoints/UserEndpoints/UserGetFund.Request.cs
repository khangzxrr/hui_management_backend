using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class UserGetFundRequest
{
  public const string Route = "/users/funds/{fundId}";

  [FromRoute]
  public int fundId { get; set; }

}
