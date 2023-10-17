using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Infrastructure;
using hui_management_backend.Web.Constants;
using hui_management_backend.Web.Endpoints.DTOs;
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
  private readonly IPushNotificationSender _pushNotificationSender;

  public Login(IAuthenticationService authenticationService, ITokenService tokenService, IMapper mapper, IPushNotificationSender pushNotificationSender)
  {
    _authenticationService = authenticationService;
    _tokenService = tokenService;
    _mapper = mapper;
    _pushNotificationSender = pushNotificationSender;
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

    if (result.Value.SubUsers.Count() == 0)
    {
      return BadRequest(ResponseMessageConstants.NoSubUserInfoYet);
    }

    //await _pushNotificationSender.SendPushNotificationAsync(result.Value.Id, "Đăng nhập", "Bạn vừa đăng nhập vào tài khoản");

    var response = new LoginResponse(token, _mapper.Map<SubUserRecord>(result.Value.SubUsers.First()));

    return Ok(response);
  }
}
