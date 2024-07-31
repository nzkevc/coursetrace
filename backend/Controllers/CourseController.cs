using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    public CourseController()
    {
    }

    [HttpGet(Name = "GetAllCourses")]
    public void Get()
    {
        return;
    }
}
