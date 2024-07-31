namespace Models
{
    public class Course
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Semester>? Semesters { get; set; }
        public List<Assignment>? Assignments { get; set; }
    }
}