using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Records;
using hui_management_backend.Web.Interfaces;
using hui_management_backend.Web.Jwts;
using Microsoft.IdentityModel.Tokens;

namespace hui_management_backend.Web.Services;

public class TokenService : ITokenService
{

  private readonly IConfiguration _configuration;

  public TokenService(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public string GenerateToken(User user)
  {
    string key = _configuration["Jwt:Key"]!;
    string issuer = _configuration["Jwt:Issuer"]!;
    string audience = _configuration["Jwt:Audience"]!;

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var claims = new[]
    {
      new Claim(ClaimTypes.Email, user.Identity),
      new Claim(AdditionalClaimTypes.UserId, user.Id.ToString()),
      new Claim(ClaimTypes.Role, user.Role.Name)
    };

    var token = new JwtSecurityToken(
     issuer,
     audience,
     claims,
     expires: DateTime.Now.AddDays(180),
     signingCredentials: credentials);

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}
