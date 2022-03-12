using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CourseManager.Entities;
using Microsoft.IdentityModel.Tokens;

namespace CourseManager.Services;

public class TokenService
{
    public string GenerateToken(User user,Role role)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(ConfigurationKey.JwtKey);
       

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name,user.Name),
                new(ClaimTypes.Role,role.Name)
            }),

            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}