namespace Models
{
    public class AssignmentCourseDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<CourseSemesterDto>? Semesters { get; set; }
    }
}