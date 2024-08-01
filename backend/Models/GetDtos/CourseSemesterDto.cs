namespace Models
{
    public class CourseSemesterDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Year { get; set; }
    }
}