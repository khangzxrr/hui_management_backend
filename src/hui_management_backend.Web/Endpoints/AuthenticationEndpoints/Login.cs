using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Web.Constants;
using hui_management_backend.Web.Endpoints.UserEndpoints;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.AuthenticationEndpoints;

public class Login : EndpointBaseAsync
  .WithRequest<LoginRequest>
  .WithActionResult<LoginResponse>
{

  private readonly IMapper _mapper;
  private readonly IAuthenticationService _authenticationService;
  private readonly ITokenService _tokenService;

  public Login(IAuthenticationService authenticationService, ITokenService tokenService, IMapper mapper)
  {
    _authenticationService = authenticationService;
    _tokenService = tokenService;
    _mapper = mapper;
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
      return BadRequest(ResponseMessageConstants.WrongPhoneNumerOrPassword);
    }

    string token = _tokenService.GenerateToken(result.Value);

    var response = new LoginResponse(token, _mapper.Map<UserRecord>(result.Value));

    return Ok(response);
  }
}
