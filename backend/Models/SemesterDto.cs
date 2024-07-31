namespace Models

{
    public class SemesterDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Year { get; set; }
        public List<SemesterCourseDto>? Courses { get; set; }
    }
}