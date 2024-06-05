using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TomasosPizzeria.Domain.Entities;
using TomasosPizzeria.UseCases.Interfaces;

namespace TomasosPizzeria.Infrastructure.Services;

public class TokenProvider(IConfiguration configuration) : ITokenProvider
{
    public string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles)
    {
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),
            SecurityAlgorithms.HmacSha256);
                
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, applicationUser.Id),
            new Claim(JwtRegisteredClaimNames.Sub, applicationUser.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        
        claims.AddRange(roles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["Jwt:ExpiryMinutes"])),
            claims: claims,
            signingCredentials: credentials);
            
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}