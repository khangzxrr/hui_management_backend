using Ardalis.ApiEndpoints;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Specifications;
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
  private readonly IRepository<SubUser> _subuserRepository;

  public Delete(IRepository<SubUser> subuserRepository, IAuthorizeService authorizeService)
  {
    _subuserRepository = subuserRepository;
    _authorizeService = authorizeService;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpDelete(DeleteRequest.Route)]
  [SwaggerOperation(
    Summary = "Delete a user",
    Description = "Delete a user",
    OperationId = "SubUsers.delete",
    Tags = new[] { "SubUsers" }
    )
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] DeleteRequest request, CancellationToken cancellationToken = default)
  {


    var userSpec = new SubUserByIdSpec(request.id);

    var subUser = await _subuserRepository.FirstOrDefaultAsync(userSpec);

    if (subUser == null)
    {
      return NotFound(ResponseMessageConstants.SubUserIsNotFound);
    }

    try
    {
      await _subuserRepository.DeleteAsync(subUser);

      await _subuserRepository.SaveChangesAsync();

    }
    catch
    {
      return BadRequest(ResponseMessageConstants.UserHasBillsOrAttendInFunds);
    }

    

    return Ok();
  }
}
