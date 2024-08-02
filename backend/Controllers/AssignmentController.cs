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
    public async Task<ActionResult<AssignmentDto>> Create(AssignmentPostDto assignment)
    {
        var createdAssignment = await _assignmentService.CreateAssignment(assignment);
        return CreatedAtRoute("GetAssignmentById", new { id = createdAssignment.Id }, createdAssignment);
    }

    [HttpPut("{id}", Name = "UpdateAssignment")]
    public async Task<IActionResult> Update(int id, AssignmentPostDto assignment)
    {
        try
        {
            await _assignmentService.UpdateAssignment(id, assignment);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error updating assignment");
            return BadRequest();
        }
        return Ok();
    }

    [HttpDelete("{id}", Name = "DeleteAssignment")]
    public async Task<IActionResult> Delete(int id)
    {
        await _assignmentService.DeleteAssignment(id);
        return NoContent();
    }
}
