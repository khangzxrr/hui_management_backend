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

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class GetAll : EndpointBaseAsync
  .WithRequest<GetAllRequest>
  .WithActionResult<GetAllResponse>
{
  private readonly IAuthorizeService _authorizeService;
  private readonly IMapper _mapper;
  private readonly IRepository<SubUser> _subuserRepository;

  public GetAll(IRepository<SubUser> subuserRepository, IMapper mapper, IAuthorizeService authorizeService)
  {
    _subuserRepository = subuserRepository;
    _mapper = mapper;
    _authorizeService = authorizeService;
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
    IEnumerable<SubUser> subusers;

    var userWithPaymentSpec = new SubUserWithPaymentByCreatorIdSpec(_authorizeService.UserId);
    subusers = await _subuserRepository.ListAsync(userWithPaymentSpec);

    var userRecords = subusers.Select(_mapper.Map<SubUserRecord>);

    var response = new GetAllResponse
    {
      SubUsers = userRecords
    };

    return Ok(response);
  }
}
