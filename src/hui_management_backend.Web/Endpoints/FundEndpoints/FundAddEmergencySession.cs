using Ardalis.ApiEndpoints;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundAddEmergencySession : EndpointBaseAsync
  .WithRequest<FundAddEmergencySessionRequest>
  .WithActionResult
{
  private readonly IAuthorizeService _authorizeService;
  private readonly IEmergencySessionCreateService _emergencySessionCreateService;

  public FundAddEmergencySession(IAuthorizeService authorizeService, IEmergencySessionCreateService emergencySessionCreateService)
  {
    _authorizeService = authorizeService;
    _emergencySessionCreateService = emergencySessionCreateService;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpPost(FundAddEmergencySessionRequest.Route)]
  [SwaggerOperation(
    Summary = "Fund create emergency session",
    Description = "Fund create emergency session",
    OperationId = "Fund.createEmergencySession",
    Tags = new[] { "Fund" }
    )
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] FundAddEmergencySessionRequest request, CancellationToken cancellationToken = default)
  {
    var result = await _emergencySessionCreateService.CreateEmergencySession(request.body.memberIds, request.fundId, _authorizeService.UserId);

    if (!result.IsSuccess)
    {
      return BadRequest(result.Errors.First());
    }

    return Ok(result);
  }
}
