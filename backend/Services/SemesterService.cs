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

    // TODO: need to handle malformed data and all that jazz
    public async Task CreateSemester(Semester semester)
    {
        _context.Semesters.Add(semester);
        await _context.SaveChangesAsync();
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

    public async Task<IEnumerable<SemesterDto>> GetAllSemesters()
    {
        var semesters = await _context.Semesters.Include(s => s.Courses).ToListAsync();

        return semesters.Select(s => new SemesterDto
        {
            Id = s.Id,
            Name = s.Name,
            Year = s.Year,
            Courses = s.Courses != null ? s.Courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Name = c.Name,
                Assignments = c.Assignments != null ? c.Assignments.Select(a => new AssignmentDto
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList() : new List<AssignmentDto>()
            }).ToList() : new List<CourseDto>()
        });
    }

    public async Task<Semester?> GetSemesterById(int id)
    {
        var semester = await _context.Semesters.FindAsync(id);
        return semester;
    }

    // TODO: actually implement properly
    public async Task UpdateSemester(int id, Semester semester)
    {
        var existingSemester = await _context.Semesters.FindAsync(id);

        // TODO: modify this to handle nulls? And if other fields can be changed
        if (existingSemester != null)
        {
            existingSemester.Name = semester.Name;
            existingSemester.Year = semester.Year;
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("Semester not found.");
        }
    }
}