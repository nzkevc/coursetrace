namespace Models

{
    public class AssignmentPostDto
    {
        public required string Name { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public int Weighting { get; set; }
        public DateTime DueDate { get; set; }
        public required int CourseId { get; set; }
    }
}