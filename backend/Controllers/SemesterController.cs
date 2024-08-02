using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class SemesterController : ControllerBase
{
    private readonly SemesterService _semesterService;
    private readonly ILogger<SemesterController> _logger;

    public SemesterController(SemesterService semesterService, ILogger<SemesterController> logger)
    {
        _semesterService = semesterService;
        _logger = logger;
    }

    [HttpGet(Name = "GetAllSemesters")]
    public async Task<ActionResult<IEnumerable<SemesterDto>>> Get()
    {
        var semesters = await _semesterService.GetAllSemesters();
        return Ok(semesters);
    }

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

    [HttpPost(Name = "CreateSemester")]
    public async Task<ActionResult<Semester>> Create([FromBody] SemesterPostDto semester)
    {
        var createdSemester = await _semesterService.CreateSemester(semester);
        return CreatedAtRoute("GetSemesterById", new { id = createdSemester.Id }, createdSemester);
    }

    [HttpPut("{id}", Name = "UpdateSemester")]
    public async Task<IActionResult> Update(int id, SemesterPostDto semester)
    {
        try
        {
            await _semesterService.UpdateSemester(id, semester);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error updating semester");
            return BadRequest();
        }
        return Ok();
    }

    // DELETE /Semester/{id}
    [HttpDelete("{id}", Name = "DeleteSemester")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _semesterService.DeleteSemester(id);
        return NoContent();
    }
}
