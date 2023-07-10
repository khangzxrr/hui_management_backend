using Ardalis.ApiEndpoints;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundAddMember : EndpointBaseAsync
  .WithRequest<FundAddMemberRequest>
  .WithActionResult
{

  private readonly IAddMemberFundService _addMemberFundService;
  private readonly IAuthorizeService _authorizeService;
  
  public FundAddMember(IAddMemberFundService addMemberFundService, IAuthorizeService authorizeService)
  {
    _addMemberFundService = addMemberFundService;
    _authorizeService = authorizeService;
  }

  [Authorize]
  [HttpGet(FundAddMemberRequest.Route)]
  [SwaggerOperation(
    Summary = "Fund add member",
    Description = "Fund add member",
    OperationId = "Fund.addMember",
    Tags = new[] { "Fund" }
    )
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] FundAddMemberRequest request, CancellationToken cancellationToken = default)
  {
    var result = await _addMemberFundService.AddMember(request.fundId, _authorizeService.UserId, request.memberId);

    if (!result.IsSuccess)
    {
      return BadRequest(result.Errors);
    }

    return Ok();
  }
}
