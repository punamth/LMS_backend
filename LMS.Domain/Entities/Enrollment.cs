namespace LMS.Domain.Entities
{

    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        public User User { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}