using System.Data;
using Ardalis.ApiEndpoints;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Core.PaymentAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundDelete : EndpointBaseAsync
.WithRequest<FundDeleteRequest>
  .WithActionResult
{

  private readonly IRepository<Fund> _fundRepository;
  private readonly IAuthorizeService _authorizeService;

  public FundDelete(IRepository<Fund> fundRepository, IAuthorizeService authorizeService)
  {
    _fundRepository = fundRepository;
    _authorizeService = authorizeService;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpDelete(FundDeleteRequest.Route)]
  [SwaggerOperation(
    Summary = "Fund delete by id",
    Description = "Fund delete by id",
    OperationId = "Fund.delete",
    Tags = new[] { "Fund" }
    )
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] FundDeleteRequest request, CancellationToken cancellationToken = default)
  {
    var spec = new FundByIdAndOwnerIdSpec(request.fundId, _authorizeService.UserId);

    var fund = await _fundRepository.FirstOrDefaultAsync(spec);

    if (fund == null)
    {
      return NotFound();
    }


    fund.setArchived(true);

    await _fundRepository.UpdateAsync(fund);

    return Ok();
  }
}
