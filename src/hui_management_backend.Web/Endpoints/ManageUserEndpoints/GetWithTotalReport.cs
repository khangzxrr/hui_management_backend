using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Web.Endpoints.DTOs;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.ManageUserEndpoints;

public class GetWithTotalReport : EndpointBaseAsync
  .WithRequest<GetWithTotalReportRequest>
  .WithActionResult<GetWithTotalReportResponse>
{


  private readonly IGetSubUserWithPaymentByIdService _getSubUserWithPaymentByIdService;
  private readonly IAuthorizeService _authorizeService;
  private readonly IMapper _mapper;

  public GetWithTotalReport(IGetSubUserWithPaymentByIdService getSubUserWithPaymentByIdService, IAuthorizeService authorizeService, IMapper mapper)
  {
    _getSubUserWithPaymentByIdService = getSubUserWithPaymentByIdService;
    _authorizeService = authorizeService;
    _mapper = mapper;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpGet(GetWithTotalReportRequest.Route)]
  [SwaggerOperation(
    Summary = "Get user with reports",
    Description = "Get user with reports",
    OperationId = "SubUsers.getWithReport",
    Tags = new[] { "SubUsers" }
    )
  ]
  public override async Task<ActionResult<GetWithTotalReportResponse>> HandleAsync([FromRoute] GetWithTotalReportRequest request, CancellationToken cancellationToken = default)
  {

    var result = await _getSubUserWithPaymentByIdService.getSubUserWithPaymentById(_authorizeService.UserId, request.id);

    if (result.IsSuccess)
    {
      var subuserReportRecord = _mapper.Map<SubUserReportRecord>(result.Value);
      var response = new GetWithTotalReportResponse(subuserReportRecord);

      return Ok(response);
    }

    return BadRequest(result.Errors.First());
  }
}
