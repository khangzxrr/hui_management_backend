
using Ardalis.ApiEndpoints;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class UserAddNotificationToken : EndpointBaseAsync
  .WithRequest<UserAddNotificationTokenRequest>
  .WithActionResult
{

  private readonly IAuthorizeService _authorizeService;
  private readonly IRepository<User> _userRepository;

  public UserAddNotificationToken(IAuthorizeService authorizeService, IRepository<User> userRepository)
  {
    _authorizeService = authorizeService;
    _userRepository = userRepository;
  }

  [Authorize]
  [HttpPost(UserAddNotificationTokenRequest.Route)]
  [SwaggerOperation(
       Summary = "Add new notification token",
       Description = "Ad new notification token",
       OperationId = "User.addNotificationToken",
       Tags = new[] { "UserEndpoints" }
          )
     ]
  public override async Task<ActionResult> HandleAsync([FromBody] UserAddNotificationTokenRequest request, CancellationToken cancellationToken = default)
  {
    var userSpec = new NotificationTokensByUserIdSpec(_authorizeService.UserId);

    var user = await _userRepository.FirstOrDefaultAsync(userSpec);

    if (user == null)
    {
      return NotFound();
    }

    if (user.NotificationTokens.Any(t => t.Token == request.Token))
    {
      return Ok();
    }

    user.AddNotificationToken(request.Token);

    await _userRepository.UpdateAsync(user);
    await _userRepository.SaveChangesAsync();

    return Ok();
  }
}
