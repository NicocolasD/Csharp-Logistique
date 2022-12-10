namespace Logistique.Web.Api.Controllers;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Logistique.Business.Description.BusinessModel;
using Logistique.Business.Description.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("[controller]")]

public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] Login user)
    {
        if (user == null)
            return BadRequest();
        
        if (user.Username == "nicolas" && user.Password == "nicolas")
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MaSuperSecretKey69@680"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:7091",
                audience: "http://localhost:7091",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(tokenString);
        }

        return Unauthorized();
    }
}