using hui_management_backend.Core.FundAggregate.Filters;
using hui_management_backend.Web.Endpoints.Base;
using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class GetAllRequest : PagingRequest
{
  public const string Route = "/subusers";

  [FromQuery]
  public string? searchTerm { get; set; }
}
