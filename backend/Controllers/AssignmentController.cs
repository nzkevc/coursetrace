using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class AssignmentController : ControllerBase
{
    private readonly AssignmentService _assignmentService;
    private readonly ILogger<AssignmentController> _logger;
    public AssignmentController(AssignmentService assignmentService, ILogger<AssignmentController> logger)
    {
        _assignmentService = assignmentService;
        _logger = logger;
    }

    [HttpGet(Name = "GetAllAssignments")]
    public async Task<ActionResult<IEnumerable<AssignmentDto>>> Get()
    {
        var assignments = await _assignmentService.GetAllAssignments();
        return Ok(assignments);
    }

    [HttpGet("{id}", Name = "GetAssignmentById")]
    public async Task<ActionResult<AssignmentDto>> GetById(int id)
    {
        var assignment = await _assignmentService.GetAssignmentById(id);
        if (assignment == null)
        {
            return NotFound();
        }
        return Ok(assignment);
    }

    [HttpPost(Name = "CreateAssignment")]
    public async Task<ActionResult<Assignment>> Create(CourseAssignmentDto assignment, int courseId)
    {
        await _assignmentService.CreateAssignment(assignment, courseId);
        return CreatedAtRoute("GetAssignmentById", new { id = assignment.Id }, assignment);
    }

    [HttpPut("{id}", Name = "UpdateAssignment")]
    public async Task<IActionResult> Update(int id, Assignment assignment)
    {
        // var existingAssignment = await _assignmentService.GetAssignmentById(id);
        // if (existingAssignment == null)
        // {
        //     return NotFound();
        // }
        // existingAssignment.Name = assignment.Name;
        // existingAssignment.StartDate = assignment.StartDate;
        // existingAssignment.EndDate = assignment.EndDate;
        // await _assignmentService.UpdateAssignment(existingAssignment);
        // return NoContent();
        return Ok();
    }

    [HttpDelete("{id}", Name = "DeleteAssignment")]
    public async Task<IActionResult> Delete(int id)
    {
        await _assignmentService.DeleteAssignment(id);
        return NoContent();
    }
}
