using Ardalis.ApiEndpoints;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundRemoveMember : EndpointBaseAsync
  .WithRequest<FundRemoveMemberRequest>
  .WithActionResult
{

  
  private readonly IAuthorizeService _authorizeService;
  private readonly IRemoveMemberFundService _removeMemberFundService;

  public FundRemoveMember(IAuthorizeService authorizeService, IRemoveMemberFundService removeMemberFundService)
  {
    _authorizeService = authorizeService;
    _removeMemberFundService = removeMemberFundService;
  }

  [Authorize]
  [HttpGet(FundRemoveMemberRequest.Route)]
  [SwaggerOperation(
    Summary = "Fund remove member",
    Description = "Fund remove member",
    OperationId = "Fund.removeMember",
    Tags = new[] { "Fund" }
    )
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] FundRemoveMemberRequest request, CancellationToken cancellationToken = default)
  {
    var result = await _removeMemberFundService.RemoveMember(request.fundId, _authorizeService.UserId, request.memberId);

    if (!result.IsSuccess)
    {
      return BadRequest(result.Errors);
    }

    return Ok();
  }
}
