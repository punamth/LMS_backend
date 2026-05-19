namespace LMS.Domain.Entities
{

    public class Course
    {
        public int CourseId { get; set; }
        public required string CourseTitle { get; set; }
        public required string CourseDescription { get; set; }
        public string? ThumbnailPath { get; set; }

        // Navigation properties
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Test> Tests { get; set; } = new List<Test>();
    }
}