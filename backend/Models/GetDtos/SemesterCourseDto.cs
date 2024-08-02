namespace Models

{
    public class SemesterCourseDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<CourseAssignmentDto>? Assignments { get; set; }
    }
}