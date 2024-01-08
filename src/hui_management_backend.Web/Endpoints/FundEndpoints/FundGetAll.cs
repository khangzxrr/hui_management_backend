using System;
using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.FundAggregate.Filters;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Web.Endpoints.DTOs;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundGetAll : EndpointBaseAsync
  .WithRequest<FundGetAllRequest>
  .WithActionResult<FundGetAllResponse>
{

  private readonly IGetFundService _fundService;
  private readonly IMapper _mapper;
  private readonly IAuthorizeService _authorizeService;


  public FundGetAll(IGetFundService fundService, IMapper mapper, IAuthorizeService authorizeService)
  {
    _fundService = fundService;
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
  public override async Task<ActionResult<FundGetAllResponse>> HandleAsync([FromRoute] FundGetAllRequest request, CancellationToken cancellationToken = default)
  {

    var filter = new FundFilter(request.onlyDayFund, request.onlyMonthFund, request.searchTerm);

    //overcome optional filters => create new list of filter
    var fundsResult = await _fundService.getFunds(_authorizeService.UserId, request.skip, request.pageSize, filter);

    if (fundsResult.IsSuccess)
    {
      var response = new FundGetAllResponse(fundsResult.Value.Select(_mapper.Map<GeneralFundRecord>));
      return Ok(response);
    }

    return BadRequest(fundsResult.Errors);
  }
}
