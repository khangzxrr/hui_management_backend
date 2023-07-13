using hui_management_backend.Web.Interfaces;
using hui_management_backend.Web.Jwts;

namespace hui_management_backend.Web.Services;

public class AuthorizeService : IAuthorizeService
{

  private readonly IHttpContextAccessor _contextAccessor;

  public AuthorizeService(IHttpContextAccessor contextAccessor)
  {
    _contextAccessor = contextAccessor;
  }

  public int UserId => int.Parse(_contextAccessor.HttpContext!.User.Claims.Where(c => c.Type == AdditionalClaimTypes.UserId).First().Value);
}
