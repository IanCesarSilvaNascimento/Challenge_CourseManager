using CourseManager.Data;
using CourseManager.Entities;
using CourseManager.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class CourseController : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("v1")]
    public IActionResult GetCourse(
        [FromServices] AppDbContext context)
    {
        var item = context.Courses.OrderBy(x => x.Id).ToList();
        return Ok(item);
    }

    [AllowAnonymous]
    [HttpGet("v1/{status}")]
    public IActionResult GetCourseByStatus(
          [FromRoute] int status,
          [FromServices] AppDbContext context)
    {

        var course = context
            .Courses
            .Where(x => ((int)x.Status) == status)
            .Select(x => new Course()
            {
                Id = x.Id,
                Title = x.Title,
                Duration = x.Duration,
                Status = x.Status
            })
            .ToList();
        if (course == null)
            return NotFound();

        return Ok(course);
    }


    [Authorize(Roles = ConstantConfiguration.AllRoles)]
    [HttpPost("v1")]
    public IActionResult PostCourse(
          [FromBody] EditorCourseViewModel model,
          [FromServices] AppDbContext context)
    {
        var course = new Course
        {
            Title = model.Title,
            Duration = model.Duration,
            Status = model.Status

        };
        context.Courses.Add(course);
        context.SaveChanges();

        return Created($"get-courses/{course}", course);
    }


    [Authorize(Roles = ConstantConfiguration.AllRoles)]
    [HttpPut("v1/{id:int}")]
    public IActionResult PutCourse(
           [FromRoute] int id,
           [FromBody] EditorCourseViewModel model,
           [FromServices] AppDbContext context)
    {
        var course = context.Courses.FirstOrDefault(x => x.Id == id);

        if (model == null)
            return NotFound();

        course.Title = model.Title;
        course.Duration = model.Duration;
        course.Status = model.Status;

        context.Courses.Update(course);
        context.SaveChanges();
        return Ok(model);
    }


    [Authorize(Roles = ConstantConfiguration.RoleAdmin)]

    [HttpDelete("v1/{id:int}")]
    public IActionResult DeleteCourse(
             [FromRoute] int id,
             [FromServices] AppDbContext context)
    {
        var model = context.Courses.FirstOrDefault(x => x.Id == id);
        if (model == null)
            return NotFound();

        context.Courses.Remove(model);
        context.SaveChanges();

        return Ok(model);
    }


}
