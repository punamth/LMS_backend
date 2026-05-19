namespace LMS.Application.Features.Lessons.DTOs
{
    public class LessonDto
    {
        public int LessonId { get; set; }

        public int CourseId { get; set; }

        public required string LessonTitle { get; set; }

        public required string ContentText { get; set; }

        public string? VideoPath { get; set; }
    }
}