namespace LMS.Domain.Entities
{
    public class TestAttempt
    {
        public int TestAttemptId { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public required string SelectedAnswer { get; set; }
        public int Score { get; set; }
        public DateTime AttemptedAt { get; set; } = DateTime.UtcNow;
        public User User { get; set; } = null!;
        public Test Test { get; set; } = null!;
    }
}