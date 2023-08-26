using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Endpoints.DTOs;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.ManageUserEndpoints;

public class GetAllWithTotalReport : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult<GetAllWithTotalReportResponse>
{

  private readonly IRepository<SubUser> _subUserRepository;
  private readonly IAuthorizeService _authorizeService;
  private readonly IMapper _mapper;

  public GetAllWithTotalReport(IRepository<SubUser> subUserRepository, IAuthorizeService authorizeService, IMapper mapper)
  {
    _subUserRepository = subUserRepository;
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
  public override async Task<ActionResult<GetAllWithTotalReportResponse>> HandleAsync(CancellationToken cancellationToken = default)
  {

    var subuserSpec = new SubUserWithPaymentByCreatorIdSpec(_authorizeService.UserId);

    var subusers = await _subUserRepository.ListAsync(subuserSpec);

    var subuserWithReports = subusers.Select(_mapper.Map<SubUserReportRecord>);

    var response = new GetAllWithTotalReportResponse(subuserWithReports);

    return Ok(response);
  }
}
