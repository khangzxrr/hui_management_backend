using Ardalis.ApiEndpoints;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundSetArchive : EndpointBaseAsync
  .WithRequest<FundSetArchiveRequest>
  .WithActionResult
{

  private readonly IRepository<Fund> _fundRepository;

  private readonly IAuthorizeService _authorizeService;

  public FundSetArchive(IRepository<Fund> fundRepository, IAuthorizeService authorizeService)
  {
    _fundRepository = fundRepository;
    _authorizeService = authorizeService;
  }


  [Authorize]
  [HttpGet(FundSetArchiveRequest.Route)]
  [SwaggerOperation(
    Summary = "set archived",
    Description = "set archived",
    OperationId = "Fund.archived",
    Tags = new[] { "Fund" }
    )
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] FundSetArchiveRequest request, CancellationToken cancellationToken = default)
  {
    var spec = new FundByIdAndOwnerId(request.id, _authorizeService.UserId);

    var fund = await _fundRepository.FirstOrDefaultAsync(spec);

    if (fund == null)
    {
      return NotFound();
    }

    fund.SetArchived(request.isArchived);

    await _fundRepository.UpdateAsync(fund);
    await _fundRepository.SaveChangesAsync();

    return Ok();
  }
}
