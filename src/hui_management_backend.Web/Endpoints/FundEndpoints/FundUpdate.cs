﻿using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Events;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;
using hui_management_backend.Web.Endpoints.DTOs;
using hui_management_backend.Web.Interfaces;
using MediatR;
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

  private readonly IMediator _mediator;

  public FundUpdate(IRepository<Fund> fundRepository, IAuthorizeService authoizeService, IMapper mapper, IMediator mediator)
  {
    _fundRepository = fundRepository;
    _authorizeService = authoizeService;
    _mapper = mapper;
    _mediator = mediator;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
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
    FundType fundType;
    bool successParsedFundType = FundType.TryFromName(request.fundType, true, out fundType);
    if (!successParsedFundType)
    {
      return BadRequest(ResponseMessageConstants.CannotParseFundType);
    }

    var spec = new FundByIdAndOwnerIdSpec(request.id, _authorizeService.UserId);

    var fund = await _fundRepository.FirstOrDefaultAsync(spec);

    if (fund == null)
    {
      return NotFound();
    }

    fund.SetName(request.name);
    fund.SetServiceCost(request.serviceCost);
    fund.SetOpenDate(request.openDate);
    fund.SetNewSessionDurationDayCount(request.newSessionDurationCount);
    fund.SetTakenSessionDeliveryDayCount(request.takenSessionDeliveryCount);
    fund.SetFundPrice(request.fundPrice);
    fund.SetFundType(fundType);
    fund.SetNewSessionCreateDayOfMonth(request.newSessionCreateDayOfMonth);
    fund.SetNewSessionCreateHourOfDay(request.newSessionCreateHourOfDay);
    fund.SetTakenSessionDeliveryHourOfDay(request.takenSessionDeliveryHourOfDay);

    await _fundRepository.UpdateAsync(fund);

    //FundUpdateEvent fundUpdateEvent = new FundUpdateEvent(fund, oldFundPrice, oldServicePrice);
    //await _mediator.Publish(fundUpdateEvent);

    await _fundRepository.SaveChangesAsync();

    var fundRecord = _mapper.Map<FundRecord>(fund);

    var response = new FundUpdateResponse(fundRecord);

    return Ok(response);
  }
}
