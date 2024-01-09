using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.UserAggregate.Enums;
using hui_management_backend.Web.Endpoints.DTOs;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.ManageUserEndpoints;

public class GetAllWithTotalReport : EndpointBaseAsync
  .WithRequest<GetAllWithTotalReportRequest>
  .WithActionResult<GetAllWithTotalReportResponse>
{

  private readonly IGetAllSubUserWithPaymentService _getAllSubUserWithPaymentService;
  private readonly IAuthorizeService _authorizeService;
  private readonly IMapper _mapper;

  public GetAllWithTotalReport(IGetAllSubUserWithPaymentService getAllSubUserWithPaymentService, IAuthorizeService authorizeService, IMapper mapper)
  {
    _getAllSubUserWithPaymentService = getAllSubUserWithPaymentService;
    _authorizeService = authorizeService;
    _mapper = mapper;
  }


  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpGet(GetAllWithTotalReportRequest.Route)]
  [SwaggerOperation(
    Summary = "Get all users with reports",
    Description = "Get all users with reports",
    OperationId = "SubUsers.getAllWithReport",
    Tags = new[] { "SubUsers" }
    )
  ]
  public override async Task<ActionResult<GetAllWithTotalReportResponse>> HandleAsync([FromRoute] GetAllWithTotalReportRequest request, CancellationToken cancellationToken = default)
  {

    var filter = new SubUserWithPaymentReportFilter(request.atLeastOnePayment, request.todayPayment, request.unfinishedPayment);

    var result = await _getAllSubUserWithPaymentService.GetAllSubUserWithPayment(_authorizeService.UserId, request.skip, request.take, request.searchTerm, filter);

    if (result.IsSuccess)
    {
      var subuserReportRecords = result.Value.Select(_mapper.Map<SubUserReportRecord>);
      var response = new GetAllWithTotalReportResponse(subuserReportRecords);

      return Ok(response);
    }

    return BadRequest(result.Errors.First());
  }
}
