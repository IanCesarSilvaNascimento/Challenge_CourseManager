using CourseManager.Data;
using CourseManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{   
    [HttpPost("v1")]
    public IActionResult LoginAccount(
       [FromServices] AppDbContext context,
       [FromServices] TokenService tokenService)
    {
        var lastUserCreated = context.Users.OrderBy(x=>x.Id).LastOrDefault();

        var lastRoleCreated = context.Roles.OrderBy(x=>x.Id).LastOrDefault();

        if (lastUserCreated.RoleId == lastRoleCreated.Id)
        {
            var token = tokenService.GenerateToken(lastUserCreated, lastRoleCreated);
            return Ok(token);
        }
      
        return NotFound();
    }
  
}
