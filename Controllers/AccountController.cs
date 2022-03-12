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
    public IActionResult GetUsers([FromServices] AppDbContext context)
        => Ok(context.Users.ToList());

    [HttpGet("v1/[controller]/gets/roles")]
    public IActionResult GetRoles([FromServices] AppDbContext context)
        => Ok(context.Roles.ToList());



    [HttpPost("v1/[controller]/posts")]
    public IActionResult PostAccount(
        [FromBody] EditorUserViewModel model,
        [FromServices] AppDbContext context
    )
    {
        var role = new Role
        {
            Name = model.Role
        };
        var user = new User
        {
            Name = model.UserName,
        
        };
        user.Role.Add(role);
      

        context.Users.Add(user);
        context.SaveChanges();


        // return Created($"v1/[controller]/gets/{user}", user);
        return Ok(user);
    }



    [HttpPost("v1/[controller]/logins")]
    public IActionResult LoginAccount(
       [FromServices] AppDbContext context,
       [FromServices] TokenService tokenService,
       [FromBody] EditorUserViewModel model

   )
    {

        var user = context.Users.FirstOrDefault(x => x.Name == model.UserName);
        var token = tokenService.GenerateToken(user);

        return Ok(token);
    }




    [HttpDelete("v1/[controller]/deletes/{id:int}")]
    public IActionResult DeleteAccount(
        [FromRoute] int id,
        [FromServices] AppDbContext context)
    {
        var model = context.Users.FirstOrDefault(x => x.Id == id);
        if (model == null)
            return NotFound();

        context.Users.Remove(model);
        context.SaveChanges();

        return Ok(model);
    }
}
