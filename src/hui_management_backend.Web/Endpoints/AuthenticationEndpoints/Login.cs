using Ardalis.ApiEndpoints;
using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.AuthenticationEndpoints;

public class Login : EndpointBaseAsync
  .WithRequest<LoginRequest>
  .WithActionResult<LoginResponse>
{

  private readonly IAuthenticationService _authenticationService;
  private readonly ITokenService _tokenService;

  public Login(IAuthenticationService authenticationService, ITokenService tokenService)
  {
    _authenticationService = authenticationService;
    _tokenService = tokenService;
  }


  [HttpPost(LoginRequest.Route)]
  [SwaggerOperation(
    Summary = "Login by email/password",
    Description = "Login by email/password",
    OperationId = "Authen.Login",
    Tags = new[] { "Authen" }
    )
  ]
  public override async Task<ActionResult<LoginResponse>> HandleAsync([FromBody] LoginRequest request, CancellationToken cancellationToken = default)
  {
    var result = await _authenticationService.Login(request.phonenumber, request.password);

    if (!result.IsSuccess)
    {
      return result.Map(u => new LoginResponse()).ToActionResult(this);
    }

    string token = _tokenService.GenerateToken(result.Value);

    var response = new LoginResponse
    {
      Email = result.Value.Email,
      Name = result.Value.Name,
      Phonenumber = result.Value.PhoneNumber,
      Token = token
    };

    return Ok(response);
  }
}
