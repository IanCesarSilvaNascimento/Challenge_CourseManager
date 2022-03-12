using System.Security.Claims;
using CourseManager.Entities;

namespace CourseManager.Extensions;

public static class RoleClaimsExtension
{
    public static IEnumerable<Claim> GetClaims(this User user)
    {
        var result = new List<Claim>
        {
            new(ClaimTypes.Name, user.Name)
        };
        result.AddRange(
            user.Role.Select(role => new Claim(ClaimTypes.Role, role.Name))
         
        );

        return result;
    }
}