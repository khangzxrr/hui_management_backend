using Ardalis.ApiEndpoints;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class Delete : EndpointBaseAsync
  .WithRequest<DeleteRequest>
  .WithActionResult
{


  private readonly IAuthorizeService _authorizeService;
  private readonly IRepository<User> _userRepository;

  public Delete(IRepository<User> userRepository, IAuthorizeService authorizeService)
  {
    _userRepository = userRepository;
    _authorizeService = authorizeService;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpDelete(DeleteRequest.Route)]
  [SwaggerOperation(
    Summary = "Delete a user",
    Description = "Delete a user",
    OperationId = "Users.delete",
    Tags = new[] { "Users" }
    )
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] DeleteRequest request, CancellationToken cancellationToken = default)
  {

    var owner = await _userRepository.GetByIdAsync(_authorizeService.UserId);

    if (owner == null)
    {
      return BadRequest(ResponseMessageConstants.OwnerNotFound);
    }

    var user = await _userRepository.GetByIdAsync(request.id);

    if (user == null)
    {
      return NotFound();
    }

    user.RemoveCreateBy(owner);

    await _userRepository.SaveChangesAsync();

    return Ok();
  }
}
