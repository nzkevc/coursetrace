using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class AssignmentController : ControllerBase
{
    public AssignmentController()
    {
    }

    [HttpGet(Name = "GetAllAssignments")]
    public void Get()
    {
        return;
    }
}
