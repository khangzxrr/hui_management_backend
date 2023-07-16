using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.ManageUserEndpoints;

public class GetUserPayments : EndpointBaseAsync
  .WithRequest<GetUserPaymentsRequest>
  .WithActionResult
{

  [HttpGet(GetUserPaymentsRequest.Route)]
  public override Task<ActionResult> HandleAsync(GetUserPaymentsRequest request, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }
}
