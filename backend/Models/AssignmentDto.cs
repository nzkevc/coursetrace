namespace Models

{
    public class AssignmentDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public int Weighting { get; set; }
        public DateTime DueDate { get; set; }
    }
}