using Ardalis.ApiEndpoints;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundAddSession : EndpointBaseAsync
  .WithRequest<FundAddSessionRequest>
  .WithActionResult
{

  private readonly IAuthorizeService _authorizeService;
  private readonly IAddSessionFundService _addSessionFundService;
  public FundAddSession(IAuthorizeService authorizeService, IAddSessionFundService addSessionFundService)
  {
    _authorizeService = authorizeService;
    _addSessionFundService = addSessionFundService;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpPost(FundAddSessionRequest.Route)]
  [SwaggerOperation(
    Summary = "Fund create session",
    Description = "Fund create session",
    OperationId = "Fund.createSession",
    Tags = new[] { "Fund" }
    )
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] FundAddSessionRequest request, CancellationToken cancellationToken = default)
  {
    var result = await _addSessionFundService.AddSession(request.fundId, _authorizeService.UserId, request.body.memberId, request.body.predictPrice);

    if (!result.IsSuccess)
    {
      return BadRequest(result.Errors);
    }

    return Ok(result.Value);
  }
}
