namespace LMS.Domain.Entities
{

    public class Lesson
    {
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public required string LessonTitle { get; set; }
        public required string ContentText { get; set; }
        public string? VideoPath { get; set; }
        public Course Course { get; set; } = null!;
        public ICollection<Progress> Progresses { get; set; } = new List<Progress>();
    }
}