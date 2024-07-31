using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using Services;
using Models;

namespace Tests;

public class SemesterServiceTests
{
    private readonly SemesterService _service;
    private readonly Mock<CoursesContext> _mockContext;

    // TODO: CURRENTLY BROKEN. MAKE WORK.
    public SemesterServiceTests()
    {
        _mockContext = new Mock<CoursesContext>();
        _service = new SemesterService(_mockContext.Object);
    }

    [Fact]
    public async Task CreateSemester_ShouldAddSemester()
    {
        var semester = new Semester { Id = 1, Name = "Sem 1 2021", Year = 2021 };

        await _service.CreateSemester(semester);

        _mockContext.Verify(m => m.Semesters.Add(semester), Times.Once);
        _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
    }
}