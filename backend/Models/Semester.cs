namespace Models
{
    public class Semester
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Year { get; set; }
        public List<Course>? Courses { get; set; }
    }
}