using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Endpoints.DTOs;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundGetAll : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult<FundGetAllResponse>
{

  private readonly IRepository<Fund> _fundRepository;
  private readonly IMapper _mapper;
  private readonly IAuthorizeService _authorizeService;


  public FundGetAll(IRepository<Fund> fundRepository, IMapper mapper, IAuthorizeService authorizeService)
  {
    _fundRepository = fundRepository;
    _mapper = mapper;
    _authorizeService = authorizeService;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpGet(FundGetAllRequest.Route)]
  [SwaggerOperation(
    Summary = "Get all funds of owner",
    Description = "Get all funds of owner",
    OperationId = "Fund.getAll",
    Tags = new[] { "Fund" }
    )
  ]
  public override async Task<ActionResult<FundGetAllResponse>> HandleAsync(CancellationToken cancellationToken = default)
  {
    var spec = new FundsByOwnerIdSpec(_authorizeService.UserId);
    var funds = await _fundRepository.ListAsync(spec);

    var fundRecords = funds.Select(_mapper.Map<GeneralFundRecord>); 

    var response = new FundGetAllResponse(fundRecords);

    return Ok(response);
  }
}
