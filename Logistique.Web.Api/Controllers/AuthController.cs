namespace Logistique.Web.Api.Controllers;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
    private readonly IUserService _service;
    public AuthController(IUserService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] Login user)
    {
        if (user == null)
            return BadRequest();
        
        var userFromBase = await _service.GetByUsername(user.Username);
        if (userFromBase == null)
            return NotFound($"Aucun utilisateur avec l'username {user.Username} n'a été trouvé.");
        
        if (VerifyPasswordHash(user.Password, userFromBase.PasswordHash, userFromBase.PasswordSalt))
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MaSuperSecretKey69@680"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                //issuer: "https://localhost:7091",
                //audience: "https://localhost:7091",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(tokenString);
        }

        return Unauthorized();
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] User newUser)
    {
        try
        {
            if (newUser == null)
                return BadRequest();

            if (await _service.GetByUsername(newUser.Username) != null)
                return BadRequest($"Un utilisateur avec l'username {newUser.Username} éxiste déjà.");
            
            await _service.AddUser(newUser);
            return Ok("Votre compte utilisateur a bient été créé.");
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Erreur interne : {ex.Message}");
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}