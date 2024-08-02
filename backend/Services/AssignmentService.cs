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

    public async Task<AssignmentDto> CreateAssignment(AssignmentPostDto assignment)
    {
        var course = await _context.Courses.Include(c => c.Semesters).FirstOrDefaultAsync(c => c.Id == assignment.CourseId);

        // Test if this works (linking)
        var createdAssignment = new Assignment
        {
            Name = assignment.Name,
            Score = assignment.Score,
            MaxScore = assignment.MaxScore,
            Weighting = assignment.Weighting,
            DueDate = assignment.DueDate,
            CourseId = assignment.CourseId
        };

        _context.Assignments.Add(createdAssignment);
        await _context.SaveChangesAsync();

        var assignmentDto = new AssignmentDto
        {
            Id = createdAssignment.Id,
            Name = createdAssignment.Name,
            Score = createdAssignment.Score,
            MaxScore = createdAssignment.MaxScore,
            Weighting = createdAssignment.Weighting,
            DueDate = createdAssignment.DueDate,
            CourseId = createdAssignment.CourseId,
            Course = course != null ? new AssignmentCourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Semesters = course.Semesters?.Select(s => new CourseSemesterDto
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList()
            } : null
        };

        return assignmentDto;
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

    public async Task UpdateAssignment(int id, AssignmentPostDto assignment)
    {
        var existingAssignment = await _context.Assignments.FindAsync(id);
        if (existingAssignment != null)
        {
            existingAssignment.Name = assignment.Name;
            existingAssignment.Score = assignment.Score;
            existingAssignment.MaxScore = assignment.MaxScore;
            existingAssignment.Weighting = assignment.Weighting;
            existingAssignment.DueDate = assignment.DueDate;
            existingAssignment.CourseId = assignment.CourseId;
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("Assignment not found.");
        }
    }
}