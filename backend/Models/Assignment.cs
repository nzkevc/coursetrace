namespace Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        /**
        * Weighting is a percentage of the total grade that this assignment is worth.
        * For example, if the total grade is 100 and this assignment is worth 20% of the total grade,
        * then the Weighting would be 20.
        */
        public int Weighting { get; set; }
        public DateTime DueDate { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}