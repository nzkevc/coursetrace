namespace Models

{
    public class SemesterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}