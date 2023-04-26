using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using backend.Utils;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
  private readonly IConfiguration configuration;
  private readonly IUserService userService;
  private readonly IEncode encode;
  public LoginController(IConfiguration _configuration, IUserService _userService, IEncode _encode)
  {
    this.configuration = _configuration;
    this.userService = _userService;
    this.encode = _encode;
  }

  [HttpPost("")]
  public IActionResult GetAllProperties(User user)
  {
    if (!ValidateUser(user, out User? userValidated)) return Unauthorized(new { message = "Invalid credentials" });
    DateTime expiration = DateTime.Now.AddMinutes(30);
    string applicationName = "CPAPI";
    string tk = CustomTokenJWT(applicationName, expiration);
    return Ok(new
    {
      token = tk,
      name = userValidated.Name,
      email = userValidated.Email,
      expiration = expiration
    });
  }

  private bool ValidateUser(User user, out User? userValidated)
  {
    try {

    userValidated = userService.GetOneByUsername(user.Username);
    if (userValidated == null) return false;
    return user.Password == encode.Desencriptar(userValidated.Password);
    } catch (Exception) {
      userValidated = null;
      return false;
    }
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
