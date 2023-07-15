using System.Linq;
using Ardalis.ApiEndpoints;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundRemoveSession : EndpointBaseAsync
  .WithRequest<FundRemoveSessionRequest>
  .WithActionResult
{

  private readonly IAuthorizeService _authorizeService;
  private readonly IRepository<Fund> _fundRepository;

  public FundRemoveSession(IAuthorizeService authorizeService, IRepository<Fund> fundRepository)
  {
    _authorizeService = authorizeService;
    _fundRepository = fundRepository;
  }

  [Authorize]
  [HttpDelete(FundRemoveSessionRequest.Route)]
  [SwaggerOperation(
    Summary = "Fund remove session",
    Description = "Fund remove session",
    OperationId = "Fund.removeSession",
    Tags = new[] { "Fund" }
    )
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] FundRemoveSessionRequest request, CancellationToken cancellationToken = default)
  {
    var spec = new FundByIdAndOwnerIdSpec(request.fundId, _authorizeService.UserId);

    var fund = await _fundRepository.FirstOrDefaultAsync(spec);

    if (fund == null)
    {
      return NotFound(ResponseMessageConstants.FundNotFound);
    }

    var session = fund.Sessions.Where(s => s.Id == request.sessionId).FirstOrDefault();

    if (session == null)
    {
      return NotFound(ResponseMessageConstants.SessionNotFound);
    }

    fund.RemoveSession(session);

    await _fundRepository.UpdateAsync(fund);

    await _fundRepository.SaveChangesAsync();


    return Ok();
  }
}
