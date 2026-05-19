namespace LMS.Application.Features.Progress.DTOs
{
    public class ProgressDto
    {
        public int ProgressId { get; set; }

        public int UserId { get; set; }

        public int LessonId { get; set; }

        public DateTime CompletedAt { get; set; }
    }
}