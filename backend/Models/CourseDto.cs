namespace Models

{
    public class CourseDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<AssignmentDto>? Assignments { get; set; }
    }
}