using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class Create : EndpointBaseAsync
  .WithRequest<CreateRequest>
  .WithActionResult<CreateResponse>
{

  private readonly IRepository<User> _userRepository;
  private readonly IMapper _mapper;

  public Create(IRepository<User> userRepository, IMapper mapper)
  {
    _userRepository = userRepository;
    _mapper = mapper;
  }

  [Authorize]
  [HttpPost(CreateRequest.Route)]
  [SwaggerOperation(
    Summary = "Create new user",
    Description = "Create new user",
    OperationId = "Users.create",
    Tags = new[] { "Users" }
    )
  ]
  public override async Task<ActionResult<CreateResponse>> HandleAsync([FromBody] CreateRequest request, CancellationToken cancellationToken = default)
  {
    var user = new User(request.email, request.password, request.name, request.address, request.bankname, request.banknumber, request.phonenumber, request.additionalInfo);

    await _userRepository.AddAsync(user);

    await _userRepository.SaveChangesAsync();

    var response = new CreateResponse(_mapper.Map<UserRecord>(user));


    return Ok(response);
  }
}
