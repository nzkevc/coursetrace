namespace backend.Tests;

using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using backend.Services;
using backend.Models;

public class SemesterServiceTests
{
    private readonly SemesterService _service;
    private readonly Mock<CoursesContext> _mockContext;

    public SemesterServiceTests()
    {
        _mockContext = new Mock<CoursesContext>();
        _service = new SemesterService(_mockContext.Object);
    }

    [Fact]
    public async Task CreateSemester_ShouldAddSemester()
    {
        var semester = new Semester { /* initialize properties */ };

        await _service.CreateSemester(semester);

        _mockContext.Verify(m => m.Semesters.Add(semester), Times.Once);
        _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
    }
}