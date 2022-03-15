using CourseManager.Data;
using CourseManager.Entities;
using CourseManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpGet("v1/users")]
    public IActionResult GetUsers(
        [FromServices] AppDbContext context)
        => Ok(context.Users.ToList());

    [HttpGet("v1/roles")]
    public IActionResult GetRoles(
        [FromServices] AppDbContext context)
        => Ok(context.Roles.ToList());

    [HttpPost("v1")]
    public IActionResult CreateAccount(
        [FromBody] EditorUserViewModel model,
        [FromServices] AppDbContext context)
    {
        // Search in context for a role with the same name as the model
        var verifyRoleContext = context
                .Roles
                .Where(x => x.Name == model.RoleName)
                .Select(x => x.Name)
                .Contains(model.RoleName);

       //Given insert user in the role exists        
        if (verifyRoleContext)
        {
            var item = context
                .Roles
                .FirstOrDefault(x => x.Name == model.RoleName);
            
            var user = new User
            {
                Name = model.UserName,
                RoleId = item.Id
            };
            item.Users.Add(user);
            context.SaveChanges();                     

            return Ok(item);

        }
        //Given create new role and insert user
        else 
        {
            var user = new User
            {
                Name = model.UserName
            };
            var newRole = new Role
            {
                Name = model.RoleName
            };
            newRole.Users.Add(user);
            context.Roles.Add(newRole);
            context.SaveChanges();
            return Ok(newRole);
        }

    }

    [HttpDelete("v1")]
    public IActionResult DeleteAccount(
        [FromServices] AppDbContext context)
    {
        var lastUserCreated = context.Users.OrderBy(x => x.Id).LastOrDefault();

        context.Users.Remove(lastUserCreated);
        context.SaveChanges();
    
        return Ok();
    }
}
