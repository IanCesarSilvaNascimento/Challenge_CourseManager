using CourseManager.Data;
using CourseManager.Entities;
using CourseManager.Services;
using CourseManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Controllers;

[ApiController]
[Route("")]
public class AccountController : ControllerBase
{
    [HttpGet("v1/[controller]/gets/users")]
    public IActionResult GetUsers(
        [FromServices] AppDbContext context)
        => Ok(context.Users.ToList());

    [HttpGet("v1/[controller]/gets/roles")]
    public IActionResult GetRoles(
        [FromServices] AppDbContext context)
        => Ok(context.Roles.ToList());

    [HttpPost("v1/[controller]/posts")]
    public IActionResult CreateAccount(
        [FromBody] EditorUserViewModel model,
        [FromServices] AppDbContext context)
    {
        var user = new User
        {
            Name = model.UserName
        };

        var role = new Role
        {
            Name = model.RoleName
        };
        role.Users.Add(user);

        context.Roles.AddAsync(role);
        context.SaveChangesAsync();

        return Ok(role);
    }

    [HttpDelete("v1/[controller]/deletes")]
    public IActionResult DeleteAccount(
        [FromServices] AppDbContext context)
    {
        var lastUserCreated = context.Users.OrderBy(x => x.Id).LastOrDefault();

        var lastRoleCreated = context.Roles.OrderBy(x => x.Id).LastOrDefault();

        context.Users.Remove(lastUserCreated);
        context.SaveChanges();
        context.Roles.Remove(lastRoleCreated);
        context.SaveChanges();

        return Ok();
    }
}
