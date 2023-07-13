using Ardalis.ApiEndpoints;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class Delete : EndpointBaseAsync
  .WithRequest<DeleteRequest>
  .WithActionResult
{

  private readonly IRepository<User> _userRepository;

  public Delete(IRepository<User> userRepository)
  {
    _userRepository = userRepository;
  }

  [Authorize]
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

    var user = await _userRepository.GetByIdAsync(request.id);

    if (user == null)
    {
      return NotFound();
    }


    await _userRepository.DeleteAsync(user);

    await _userRepository.SaveChangesAsync();

    return Ok();
  }
}
