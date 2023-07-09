using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundUpdate : EndpointBaseAsync
  .WithRequest<FundUpdateRequest>
  .WithActionResult<FundUpdateResponse>
{

  private readonly IRepository<Fund> _fundRepository;

  private readonly IAuthorizeService _authorizeService;

  private readonly IMapper _mapper;

  public FundUpdate(IRepository<Fund> fundRepository, IAuthorizeService authoizeService, IMapper mapper)
  {
    _fundRepository = fundRepository;
    _authorizeService = authoizeService;
    _mapper = mapper;
  }

  [Authorize]
  [HttpPut(FundUpdateRequest.Route)]
  [SwaggerOperation(
    Summary = "Update fund",
    Description = "Update fund",
    OperationId = "Fund.update",
    Tags = new[] { "Fund" }
    )
  ]
  public override async Task<ActionResult<FundUpdateResponse>> HandleAsync([FromBody] FundUpdateRequest request, CancellationToken cancellationToken = default)
  {
    var spec = new FundByIdAndOwnerId(request.id, _authorizeService.UserId);

    var fund = await _fundRepository.FirstOrDefaultAsync(spec);

    if (fund == null)
    {
      return NotFound();
    }

    fund.SetName(request.name);
    fund.SetServiceCost(request.serviceCost);
    fund.SetOpenDate(request.openDate);
    fund.SetOpenDateText(request.openDateText);
    fund.SetFundPrice(request.fundPrice);

    await _fundRepository.UpdateAsync(fund);
    await _fundRepository.SaveChangesAsync();

    var fundRecord = _mapper.Map<FundRecord>(fund);

    var response = new FundUpdateResponse(fundRecord);

    return Ok(response);
  }
}
