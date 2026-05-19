namespace LMS.Domain.Entities
{
    public class Progress
    {
        public int ProgressId { get; set; }
        public int UserId { get; set; }
        public int LessonId { get; set; }
        public DateTime CompletedAt { get; set; } = DateTime.UtcNow;
        public User User { get; set; } = null!;
        public Lesson Lesson { get; set; } = null!;
    }
}