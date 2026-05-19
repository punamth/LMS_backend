namespace LMS.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string UserRole { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Progress> Progresses { get; set; } = new List<Progress>();
        public ICollection<TestAttempt> TestAttempts { get; set; } = new List<TestAttempt>();
    }
}