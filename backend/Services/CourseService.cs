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

    // TODO: FINISH and handle malformed data and all that jazz
    public async Task CreateCourse(CourseDto course)
    {
        // The assumption is that a semester will be created before you can create a course
        // So when creating a course, you should just be able to pass the semester id
        // And the course should be created with that semester
        // So this stuff right here is wrong
        var createdCourse = new Course
        {
            Name = course.Name,
            Semesters = course.Semesters?.Select(s => new Semester
            {
                Name = s.Name
            }).ToList(),
            Assignments = course.Assignments?.Select(a => new Assignment
            {
                Name = a.Name
            }).ToList()
        };
        _context.Courses.Add(createdCourse);
        await _context.SaveChangesAsync();
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
            }).ToList() : new List<CourseSemesterDto>(),
            Assignments = c.Assignments != null ? c.Assignments.Select(a => new CourseAssignmentDto
            {
                Id = a.Id,
                Name = a.Name
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
                    Name = s.Name
                }).ToList() ?? new List<CourseSemesterDto>(),
                Assignments = course.Assignments?.Select(a => new CourseAssignmentDto
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList() ?? new List<CourseAssignmentDto>()
            };
            return courseDto;
        }
        return null;
    }

    // TODO: actually implement properly
    public async Task UpdateCourse(int id, Course course)
    {
        // var existingSemester = await _context.Semesters.FindAsync(id);

        // // TODO: modify this to handle nulls? And if other fields can be changed
        // if (existingSemester != null)
        // {
        //     existingSemester.Name = semester.Name;
        //     existingSemester.Year = semester.Year;
        //     await _context.SaveChangesAsync();
        // }
        // else
        // {
        //     throw new ArgumentException("Semester not found.");
        // }
    }
}