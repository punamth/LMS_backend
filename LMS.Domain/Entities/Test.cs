namespace LMS.Domain.Entities
{
    public class Test
    {
        public int TestId { get; set; }

        public int CourseId { get; set; }

        public required string QuestionText { get; set; }

        public List<string> Options { get; set; } = new();

        public required string CorrectAnswer { get; set; }

        public Course Course { get; set; } = null!;

        public ICollection<TestAttempt> TestAttempts { get; set; }
            = new List<TestAttempt>();
    }
}