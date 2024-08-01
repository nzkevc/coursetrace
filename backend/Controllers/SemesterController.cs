using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class SemesterController : ControllerBase
{
    // TODO: change this to ISemesterService when I'm done!!!
    private readonly SemesterService _semesterService;
    private readonly ILogger<SemesterController> _logger;

    public SemesterController(SemesterService semesterService, ILogger<SemesterController> logger)
    {
        _semesterService = semesterService;
        _logger = logger;
    }

    // GET /Semester
    [HttpGet(Name = "GetAllSemesters")]
    public async Task<ActionResult<IEnumerable<SemesterDto>>> Get()
    {
        var semesters = await _semesterService.GetAllSemesters();
        return Ok(semesters);
    }

    // GET /Semester/{id}
    [HttpGet("{id}", Name = "GetSemesterById")]
    public async Task<ActionResult<SemesterDto>> GetById(int id)
    {
        var semester = await _semesterService.GetSemesterById(id);
        if (semester == null)
        {
            return NotFound();
        }
        return Ok(semester);
    }

    // POST /Semester
    [HttpPost(Name = "CreateSemester")]
    public async Task<ActionResult<Semester>> Create([FromBody] SemesterPostDto semester)
    {
        var createdSemester = await _semesterService.CreateSemester(semester);
        return CreatedAtRoute("GetSemesterById", new { id = createdSemester.Id }, createdSemester);
    }

    // PUT /Semester/{id}
    // TODO: properly implement this post method
    [HttpPut("{id}", Name = "UpdateSemester")]
    public async Task<IActionResult> Update(int id, Semester semester)
    {
        // var existingSemester = await _semesterService.GetSemesterById(id);
        // if (existingSemester == null)
        // {
        //     return NotFound();
        // }
        // existingSemester.Name = semester.Name;
        // existingSemester.StartDate = semester.StartDate;
        // existingSemester.EndDate = semester.EndDate;
        // _semesterService.Update(existingSemester);
        return NoContent();
    }

    // DELETE /Semester/{id}
    [HttpDelete("{id}", Name = "DeleteSemester")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _semesterService.DeleteSemester(id);
        return NoContent();
    }
}
