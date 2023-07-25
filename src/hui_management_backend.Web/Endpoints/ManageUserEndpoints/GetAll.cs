using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
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
  private readonly IRepository<User> _userRepository;

  public GetAll(IRepository<User> userRepository, IMapper mapper, IAuthorizeService authorizeService)
  {
    _userRepository = userRepository;
    _mapper = mapper;
    _authorizeService = authorizeService;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpGet(GetAllRequest.Route)]
  [SwaggerOperation(
    Summary = "Get all users",
    Description = "Get all users",
    OperationId = "Users.getAll",
    Tags = new[] { "Users" }
    )
  ]
  public override async Task<ActionResult<GetAllResponse>> HandleAsync([FromRoute] GetAllRequest request, CancellationToken cancellationToken = default)
  {
    IEnumerable<User> users;

    var userWithPaymentSpec = new UserByCreatorIdSpec(_authorizeService.UserId);
    users = await _userRepository.ListAsync(userWithPaymentSpec);

    if (request.filterByAnyPayment.HasValue)
    {
      users = users.Where(u => u.Payments.Any());
    }

    if (request.filterByNotFinishedPayment.HasValue)
    {
      users = users.Where(u => u.Payments.Where(p => p.Status != PaymentStatus.Finish).Any());
    }


    var result = await _userRepository.ListAsync();

    if (result == null)
    {
      return BadRequest();
    }

    var response = new GetAllResponse
    {
      Users = users.Select(_mapper.Map<UserRecord>)
    };

    return Ok(response);
  }
}
