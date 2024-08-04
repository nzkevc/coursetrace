using Microsoft.EntityFrameworkCore;
using Models;

namespace Services;

public class SemesterService
{
    private readonly CoursesContext _context;

    public SemesterService(CoursesContext context)
    {
        _context = context;
    }

    // This is fine, but ideally we'd want to return a SemesterDto
    public async Task<Semester> CreateSemester(SemesterPostDto semester)
    {
        var createdSemester = new Semester
        {
            Name = semester.Name,
            Year = semester.Year,
            Courses = new List<Course>()
        };

        _context.Semesters.Add(createdSemester);
        await _context.SaveChangesAsync();
        return createdSemester;
    }

    public async Task DeleteSemester(int id)
    {
        var semester = await _context.Semesters.FindAsync(id);
        if (semester != null)
        {
            _context.Semesters.Remove(semester);
            await _context.SaveChangesAsync();
        }
    }

    // TODO: fix differences in nullability of reference types or whatever that means
    public async Task<IEnumerable<SemesterDto>> GetAllSemesters()
    {
        var semesters = await _context.Semesters.Include(s => s.Courses).ThenInclude(c => c.Assignments).ToListAsync();

        return semesters.Select(s => new SemesterDto
        {
            Id = s.Id,
            Name = s.Name,
            Year = s.Year,
            Courses = s.Courses != null ? s.Courses.Select(c => new SemesterCourseDto
            {
                Id = c.Id,
                Name = c.Name,
                Assignments = c.Assignments != null ? c.Assignments.Select(a => new CourseAssignmentDto
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList() : new List<CourseAssignmentDto>()
            }).ToList() : new List<SemesterCourseDto>()
        });
    }

    public async Task<SemesterDto?> GetSemesterById(int id)
    {
        var semester = await _context.Semesters
            .Include(s => s.Courses)
                .ThenInclude(c => c.Assignments)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (semester != null)
        {
            var semesterDto = new SemesterDto
            {
                Id = semester.Id,
                Name = semester.Name,
                Year = semester.Year,
                Courses = semester.Courses?.Select(c => new SemesterCourseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Assignments = c.Assignments?.Select(a => new CourseAssignmentDto
                    {
                        Id = a.Id,
                        Name = a.Name
                    }).ToList() ?? new List<CourseAssignmentDto>()
                }).ToList() ?? new List<SemesterCourseDto>()
            };

            return semesterDto;
        }

        return null;
    }

    // Allows updating of related courses according to CourseIds in SemesterPostDto
    public async Task UpdateSemester(int id, SemesterPostDto semester)
    {
        var existingSemester = await _context.Semesters.FindAsync(id);

        if (existingSemester != null)
        {
            existingSemester.Name = semester.Name;
            existingSemester.Year = semester.Year;
            existingSemester.Courses = await _context.Courses.Where(c => semester.CourseIds == null ? false : semester.CourseIds.Contains(c.Id)).ToListAsync();
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("Semester not found.");
        }
    }
}