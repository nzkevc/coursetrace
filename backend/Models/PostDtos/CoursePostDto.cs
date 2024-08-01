namespace Models

{
    public class CoursePostDto
    {
        public required string Name { get; set; }
        public required List<int> SemesterIds { get; set; }
    }
}