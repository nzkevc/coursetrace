namespace Models
{
    public class CourseDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<CourseSemesterDto>? Semesters { get; set; }
        public List<CourseAssignmentDto>? Assignments { get; set; }
    }
}