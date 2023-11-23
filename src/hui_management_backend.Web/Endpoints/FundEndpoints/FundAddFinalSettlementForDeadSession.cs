using Ardalis.ApiEndpoints;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundAddFinalSettlementForDeadSession : EndpointBaseAsync
  .WithRequest<FundAddFinalSettlementForDeadSessionRequest>
  .WithActionResult
{

  private readonly ICreateFinalSettlementForDeadSessionService _createFinalSettlementForDeadSessionService;

  private readonly IAuthorizeService _authorizeService;

  public FundAddFinalSettlementForDeadSession(ICreateFinalSettlementForDeadSessionService createFinalSettlementForDeadSessionService, IAuthorizeService authorizeService)
  {
    _createFinalSettlementForDeadSessionService = createFinalSettlementForDeadSessionService;
    _authorizeService = authorizeService;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpPost(FundAddFinalSettlementForDeadSessionRequest.Route)]
  [SwaggerOperation(
    Summary = "Fund create final settlement for dead session",
    Description = "Fund create final settlement for dead session",
    OperationId = "Fund.createFinalSettlementForDeadSession",
    Tags = new[] { "Fund" }
    )
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] FundAddFinalSettlementForDeadSessionRequest request, CancellationToken cancellationToken = default)
  {
    var result = await _createFinalSettlementForDeadSessionService.createFinalSettlement(request.fundId, _authorizeService.UserId, request.body.memberId);

    if (result == null)
    {
      return BadRequest();
    }

    if (result.IsSuccess)
    {
      return Ok(result);
    }

    return BadRequest(result.Errors.First());
  }
}
