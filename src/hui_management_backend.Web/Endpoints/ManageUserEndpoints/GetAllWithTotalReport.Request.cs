using hui_management_backend.Core.UserAggregate.Enums;
using hui_management_backend.Web.Endpoints.Base;
using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.ManageUserEndpoints;

public class GetAllWithTotalReportRequest : PagingRequest
{
  public const string Route = "/subusers/reports";

  [FromQuery]
  public string? searchTerm { get; set; }

  [FromQuery]
  public required IEnumerable<SubUserWithPaymentReportFilter.Filter> filters { get; set; }
}
