using Microsoft.EntityFrameworkCore;
using Models;

namespace Services;

public class AssignmentService
{
    private readonly CoursesContext _context;

    public AssignmentService(CoursesContext context)
    {
        _context = context;
    }

    public async Task CreateAssignment(CourseAssignmentDto assignment, int courseId)
    {
        var createdAssignment = new Assignment
        {
            Name = assignment.Name,
            Score = assignment.Score,
            MaxScore = assignment.MaxScore,
            Weighting = assignment.Weighting,
            DueDate = assignment.DueDate,
            CourseId = courseId
        };
        _context.Assignments.Add(createdAssignment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAssignment(int id)
    {
        var assignment = await _context.Assignments.FindAsync(id);
        if (assignment != null)
        {
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<AssignmentDto>> GetAllAssignments()
    {
        var assignments = await _context.Assignments.Include(a => a.Course).ThenInclude(c => c.Semesters).ToListAsync();

        return assignments.Select(a => new AssignmentDto
        {
            Id = a.Id,
            Name = a.Name,
            Score = a.Score,
            MaxScore = a.MaxScore,
            Weighting = a.Weighting,
            DueDate = a.DueDate,
            CourseId = a.CourseId,
            Course = a.Course != null ? new AssignmentCourseDto
            {
                Id = a.Course.Id,
                Name = a.Course.Name,
                Semesters = a.Course?.Semesters?.Select(s => new CourseSemesterDto
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList()
            } : null
        });
    }

    public async Task<AssignmentDto?> GetAssignmentById(int id)
    {
        var assignment = await _context.Assignments.Include(a => a.Course).ThenInclude(c => c.Semesters).FirstOrDefaultAsync(a => a.Id == id);

        return assignment != null ? new AssignmentDto
        {
            Id = assignment.Id,
            Name = assignment.Name,
            Score = assignment.Score,
            MaxScore = assignment.MaxScore,
            Weighting = assignment.Weighting,
            DueDate = assignment.DueDate,
            CourseId = assignment.CourseId,
            Course = assignment.Course != null ? new AssignmentCourseDto
            {
                Id = assignment.Course.Id,
                Name = assignment.Course.Name,
                Semesters = assignment.Course?.Semesters?.Select(s => new CourseSemesterDto
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList()
            } : null
        } : null;
    }

    // TODO: Actually implement properly
    public async Task UpdateAssignment(Assignment assignment)
    {
        _context.Assignments.Update(assignment);
        await _context.SaveChangesAsync();
    }
}