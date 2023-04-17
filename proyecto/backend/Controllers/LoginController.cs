using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
  private readonly IPropertyService PropertyService;
  private readonly IConfiguration configuration;
  public LoginController(IPropertyService PropertyService, IConfiguration _configuration)
  {
    this.PropertyService = PropertyService;
    this.configuration = _configuration;
  }

  [HttpPost("")]
  public Token GetAllProperties(Token tokenRequest)
  {
    DateTime expiration = DateTime.Now.AddMinutes(30);
    string applicationName = "CPAPI";
    string tk = CustomTokenJWT(applicationName, expiration);
    return new Token() { token = tk, expiration = expiration };
  }

  private string CustomTokenJWT(string ApplicationName, DateTime token_expiration)
  {
    var _symmetricSecurityKey = new SymmetricSecurityKey(
      Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"])
    );
    var _signingCredentials = new SigningCredentials(
      _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
    );
    var _Header = new JwtHeader(_signingCredentials);
    var _Claims = new[] {
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
      new Claim(JwtRegisteredClaimNames.NameId, ApplicationName)
    };
    var _Payload = new JwtPayload(
      issuer: configuration["JWT:Issuer"],
      audience: configuration["JWT:Audience"],
      claims: _Claims,
      notBefore: DateTime.Now,
      expires: token_expiration
    );
    var _Token = new JwtSecurityToken(
      _Header,
      _Payload
    );
    return new JwtSecurityTokenHandler().WriteToken(_Token);
  }
}
