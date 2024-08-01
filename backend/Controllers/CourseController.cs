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
    public async Task<ActionResult<CourseDto>> Create([FromBody] CoursePostDto course)
    {
        var createdCourse = await _courseService.CreateCourse(course);
        return CreatedAtRoute("GetCourseById", new { id = createdCourse.Id }, createdCourse);
    }

    [HttpPut("{id}", Name = "UpdateCourse")]
    public async Task<IActionResult> Update(int id, CoursePostDto course)
    {
        try
        {
            await _courseService.UpdateCourse(id, course);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error updating course");
            return BadRequest();
        }
        return Ok();
    }

    [HttpDelete("{id}", Name = "DeleteCourse")]
    public async Task<IActionResult> Delete(int id)
    {
        await _courseService.DeleteCourse(id);
        return NoContent();
    }
}
