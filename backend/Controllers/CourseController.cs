using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{

    private readonly CourseService _courseService;
    private readonly ILogger<CourseController> _logger;
    public CourseController(CourseService courseService, ILogger<CourseController> logger)
    {
        _courseService = courseService;
        _logger = logger;
    }

    [HttpGet(Name = "GetAllCourses")]
    public async Task<ActionResult<IEnumerable<CourseDto>>> Get()
    {
        var courses = await _courseService.GetAllCourses();
        return Ok(courses);
    }

    [HttpGet("{id}", Name = "GetCourseById")]
    public async Task<ActionResult<CourseDto>> GetById(int id)
    {
        var course = await _courseService.GetCourseById(id);
        if (course == null)
        {
            return NotFound();
        }
        return Ok(course);
    }

    [HttpPost(Name = "CreateCourse")]
    public async Task<ActionResult<Course>> Create(Course course)
    {
        await _courseService.CreateCourse(course);
        return CreatedAtRoute("GetCourseById", new { id = course.Id }, course);
    }

    [HttpPut("{id}", Name = "UpdateCourse")]
    public async Task<IActionResult> Update(int id, Course course)
    {
        // var existingCourse = await _courseService.GetCourseById(id);
        // if (existingCourse == null)
        // {
        //     return NotFound();
        // }
        // existingCourse.Name = course.Name;
        // existingCourse.StartDate = course.StartDate;
        // existingCourse.EndDate = course.EndDate;
        // await _courseService.UpdateCourse(existingCourse);
        // return NoContent();
        return Ok();
    }

    [HttpDelete("{id}", Name = "DeleteCourse")]
    public async Task<IActionResult> Delete(int id)
    {
        await _courseService.DeleteCourse(id);
        return NoContent();
    }
}
