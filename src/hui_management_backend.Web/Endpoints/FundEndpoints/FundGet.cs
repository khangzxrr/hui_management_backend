using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundGet : EndpointBaseAsync
  .WithRequest<FundGetRequest>
  .WithActionResult<FundGetResponse>
{

  private readonly IRepository<Fund> _fundRepository;
  private readonly IAuthorizeService _authorizeService;
  private readonly IMapper _mapper;

  public FundGet(IRepository<Fund> fundRepository, IAuthorizeService authorizeService, IMapper mapper)
  {
    _fundRepository = fundRepository;
    _authorizeService = authorizeService;
    _mapper = mapper;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpGet(FundGetRequest.Route)]
  [SwaggerOperation(
    Summary = "Fund get detail by fund id",
    Description = "Fund get detail by fund id",
    OperationId = "Fund.getDetail",
    Tags = new[] { "Fund" }
    )
  ]
  public override async Task<ActionResult<FundGetResponse>> HandleAsync([FromRoute] FundGetRequest request, CancellationToken cancellationToken = default)
  {
    var spec = new FundDetailByIdAndOwnerIdSpec(request.id, _authorizeService.UserId);

    var fund = await _fundRepository.FirstOrDefaultAsync(spec);

    if (fund == null)
    {
      return NotFound();
    }

    var fundRecord = _mapper.Map<FundRecord>(fund);

    var response = new FundGetResponse(fundRecord);

    return Ok(response);
  }
}
