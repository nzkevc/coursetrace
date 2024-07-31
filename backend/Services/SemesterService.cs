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

    public async Task<IEnumerable<Semester>> GetAllSemesters()
    {
        return await _context.Semesters.ToListAsync();
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