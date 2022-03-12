using CourseManager.Data;
using CourseManager.Entities;
using CourseManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet("v1/gets")]
    public IActionResult GetUser([FromServices] AppDbContext context)
        => Ok(context.Users.ToList());



    [HttpGet("v1/gets/{id:int}")]
    public IActionResult GetUserById(
      [FromRoute] int id,
      [FromServices] AppDbContext context)
    {
        var users = context.Users.FirstOrDefault(x => x.Id == id);
        if (users == null)
            return NotFound();

        return Ok(users);
    }


    [HttpPost("v1/posts")]
    public IActionResult PostUser(
        [FromBody] EditorUserViewModel model,
        [FromServices] AppDbContext context
    )
    {
        var user = new User(model.Name, model.Role)
        {
            Name = model.Name,
            Role = model.Role
        };
        context.Users.Add(user);
        context.SaveChanges();

        return Created($"v1/gets/{user.Id}", user);
    }

    [HttpPut("v1/puts/{id:int}")]
    public IActionResult PutUser(
           [FromRoute] int id,
          [FromBody] EditorUserViewModel model,
           [FromServices] AppDbContext context)
    {
        var user = context.Users.FirstOrDefault(x => x.Id == id);

        if (model == null)
            return NotFound();

        user.Name = model.Name;
        user.Role = model.Role;

        context.Users.Update(user);
        context.SaveChanges();
        return Ok(model);
    }

    [HttpDelete("v1/deletes/{id:int}")]
    public IActionResult DeleteUser(
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
