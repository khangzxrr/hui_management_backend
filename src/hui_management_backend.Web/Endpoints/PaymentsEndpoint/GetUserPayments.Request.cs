using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public class GetUserPaymentsRequest
{
  public const string Route = "/owner/subusers/{subUserId}/payments";

  [FromRoute]
  public int subUserId { get; set; }

  [FromQuery]
  public DateTimeOffset? filerByDate { get; set; }

  [FromQuery]
  public bool? filterByProcessingOrDebting { get; set; }
}
