using hui_management_backend.Core.FundAggregate.Filters;
using hui_management_backend.Web.Endpoints.Base;
using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundGetAllRequest : PagingRequest
{
  public const string Route = "/funds";
  [FromQuery]
  public string? searchTerm { get; set; }


  [FromQuery]
  public IEnumerable<FundFilter.FundFilterEnum>? filters { get; set; } 
}
