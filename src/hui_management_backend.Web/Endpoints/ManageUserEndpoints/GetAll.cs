using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Web.Endpoints.DTOs;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class GetAll : EndpointBaseAsync
  .WithRequest<GetAllRequest>
  .WithActionResult<GetAllResponse>
{
  private readonly IAuthorizeService _authorizeService;
  private readonly IMapper _mapper;
  private readonly IGetAllSubUserService _getAllsubUserService;
  

  public GetAll(IMapper mapper, IAuthorizeService authorizeService, IGetAllSubUserService getAllSubUserService)
  {
    _mapper = mapper;
    _authorizeService = authorizeService;
    _getAllsubUserService = getAllSubUserService;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpGet(GetAllRequest.Route)]
  [SwaggerOperation(
    Summary = "Get all users",
    Description = "Get all users",
    OperationId = "SubUsers.getAll",
    Tags = new[] { "SubUsers" }
    )
  ]
  public override async Task<ActionResult<GetAllResponse>> HandleAsync([FromRoute] GetAllRequest request, CancellationToken cancellationToken = default)
  {
    var subUsers = await _getAllsubUserService.GetSubUsers(_authorizeService.UserId, request.skip, request.take, request.searchTerm);

    var userRecords = subUsers.Select(_mapper.Map<SubUserRecord>);

    var response = new GetAllResponse
    {
      SubUsers = userRecords
    };

    return Ok(response);
  }
}
