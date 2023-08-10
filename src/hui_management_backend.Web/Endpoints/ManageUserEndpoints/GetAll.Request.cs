using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class GetAllRequest
{
  public const string Route = "/subusers";

  [FromQuery]
  public bool? filterByAnyPayment { get; set; }


  [FromQuery]
  public bool? filterByNotFinishedPayment { get; set; }


}
