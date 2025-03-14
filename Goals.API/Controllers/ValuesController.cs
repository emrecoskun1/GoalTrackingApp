using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Goals.API.Security;
using Microsoft.AspNetCore.Mvc;
using TokenHandler = Microsoft.IdentityModel.Tokens.TokenHandler;

using Goals.API.Security;
using Goals.Common.Dtos;
using JwtToken.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JwtToken.Security;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    private readonly Token _token;
    
    public ValuesController(IOptions<Token> token)
    {
        _token = token.Value;
    }
    

    [HttpPost("login")]
    public IActionResult GetToken([FromBody] GetUserDto userGet)
    {
        var userDto = DoAuthentication(userGet);
        if (userDto is null)
        {
            return NotFound("Kullanıcı bulunamadı.");
        }
        var token = CreateToken(userGet);
        return Ok(token);
    }
    


    private object DoAuthentication(GetUserDto userGet)
    {
        return UsersList.Users.FirstOrDefault(x => x.UserName.ToLower() == userGet.UserName && x.UserPassword == userGet.UserPassword);
        }

    private string? CreateToken(GetUserDto userGet)
    {
        if (_token.Key == null) throw new Exception("Token Key null olamaz.");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_token.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, userGet.UserName), 
        };
        var token = new JwtSecurityToken(_token.Issuer, _token.Audience, claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}