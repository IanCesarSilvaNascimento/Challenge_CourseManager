using CourseManager.Data;
using CourseManager.Entities;
using CourseManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    [HttpGet("v1/gets")]
    public IActionResult GetCourse([FromServices] AppDbContext context)
        =>Ok(context.Courses.ToList());



    [HttpGet("v1/gets/{id:int}")]
    public IActionResult GetCourseById(
      [FromRoute] int id,
      [FromServices] AppDbContext context)
    {
        var course = context.Courses.FirstOrDefault(x => x.Id == id);
        if (course == null)
            return NotFound();

        return Ok(course);
    }


    [HttpPost("v1/posts")]
    public IActionResult PostCourse(
        [FromBody] EditorCourseViewModel model,
        [FromServices] AppDbContext context
    )
    {
        var course = new Course(model.Title, model.Status)
        {
            Title = model.Title,
            Status = model.Status
        };
        context.Courses.Add(course);
        context.SaveChanges();

        return Created($"get-courses/{course.Id}", course);
    }

    [HttpPut("v1/puts/{id:int}")]
    public IActionResult PutCourse(
           [FromRoute] int id,
           [FromBody] EditorCourseViewModel model,
           [FromServices] AppDbContext context)
    {
        var course = context.Courses.FirstOrDefault(x => x.Id == id);

        if (model == null)
            return NotFound();

        course.Title = model.Title;
        course.Status = model.Status;

        context.Courses.Update(course);
        context.SaveChanges();
        return Ok(model);
    }

    [HttpDelete("v1/deletes/{id:int}")]
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
