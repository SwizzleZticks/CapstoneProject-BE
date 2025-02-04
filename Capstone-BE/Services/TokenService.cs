using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Capstone_BE.Interfaces;
using Capstone_BE.Models;
using Microsoft.IdentityModel.Tokens;

namespace Capstone_BE.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    public string CreateToken(User aUser)
    {
        var tokenKey = Environment.GetEnvironmentVariable("TOKEN_KEY") ?? throw new Exception("Cannot access Token Key");

        if (tokenKey.Length < 64)
        {
            throw new Exception("Token Key does not meet minimum length of 64 characters.");
        }
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, aUser.Username)
        };
        
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(descriptor);
        
        return tokenHandler.WriteToken(token);
    }
}