using Microsoft.EntityFrameworkCore;
using Models;

namespace Services;

public class CourseService
{
    private readonly CoursesContext _context;

    public CourseService(CoursesContext context)
    {
        _context = context;
    }

    public async Task<CourseDto> CreateCourse(CoursePostDto course)
    {
        var semesters = await _context.Semesters.Where(s => course.SemesterIds.Contains(s.Id)).ToListAsync();

        var createdCourse = new Course
        {
            Name = course.Name,
            Semesters = semesters
        };

        _context.Courses.Add(createdCourse);
        await _context.SaveChangesAsync();

        var courseDto = new CourseDto
        {
            Id = createdCourse.Id,
            Name = createdCourse.Name,
            Semesters = createdCourse.Semesters.Select(s => new CourseSemesterDto
            {
                Id = s.Id,
                Name = s.Name,
                Year = s.Year
            }).ToList(),
            Assignments = new List<CourseAssignmentDto>()
        };

        return courseDto;
    }

    public async Task DeleteCourse(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<CourseDto>> GetAllCourses()
    {
        var courses = await _context.Courses.Include(c => c.Semesters).Include(c => c.Assignments).ToListAsync();

        return courses.Select(c => new CourseDto
        {
            Id = c.Id,
            Name = c.Name,
            Semesters = c.Semesters != null ? c.Semesters.Select(s => new CourseSemesterDto
            {
                Id = s.Id,
                Name = s.Name,
                Year = s.Year
            }).ToList() : new List<CourseSemesterDto>(),
            Assignments = c.Assignments != null ? c.Assignments.Select(a => new CourseAssignmentDto
            {
                Id = a.Id,
                Name = a.Name,
                Score = a.Score,
                MaxScore = a.MaxScore,
                Weighting = a.Weighting,
                DueDate = a.DueDate
            }).ToList() : new List<CourseAssignmentDto>()
        });
    }

    public async Task<CourseDto?> GetCourseById(int id)
    {
        var course = await _context.Courses
            .Include(c => c.Semesters)
            .Include(c => c.Assignments)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (course != null)
        {
            var courseDto = new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Semesters = course.Semesters?.Select(s => new CourseSemesterDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Year = s.Year
                }).ToList() ?? new List<CourseSemesterDto>(),
                Assignments = course.Assignments?.Select(a => new CourseAssignmentDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Score = a.Score,
                    MaxScore = a.MaxScore,
                    Weighting = a.Weighting,
                    DueDate = a.DueDate
                }).ToList() ?? new List<CourseAssignmentDto>()
            };
            return courseDto;
        }
        return null;
    }

    // Allows updating of related semesters according to SemesterIds in CoursePostDto
    public async Task UpdateCourse(int id, CoursePostDto course)
    {
        var existingCourse = await _context.Courses.FindAsync(id);
        if (existingCourse != null)
        {
            existingCourse.Name = course.Name;
            existingCourse.Semesters = await _context.Semesters.Where(s => course.SemesterIds.Contains(s.Id)).ToListAsync();
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("Course not found.");
        }
    }
}