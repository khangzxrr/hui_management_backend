using Ardalis.ApiEndpoints;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class GetAll : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult<GetAllResponse>
{

  private readonly IRepository<User> _userRepository;

  public GetAll(IRepository<User> userRepository)
  {
    _userRepository = userRepository;
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
  public override async Task<ActionResult<GetAllResponse>> HandleAsync(CancellationToken cancellationToken = default)
  {

    var result = await _userRepository.ListAsync();

    if (result == null)
    {
      return BadRequest();
    }

    var response = new GetAllResponse
    {
      Users = result.Select(u => new UserRecord(u.Id, u.Name, u.Email, u.Password, u.PhoneNumber, u.BankName, u.BankNumber, u.Address, u.AdditionalInfo))
    };

    return Ok(response);
  }
}
