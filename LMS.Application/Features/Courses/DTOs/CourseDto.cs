namespace LMS.Application.Features.Courses.DTOs
{
    public class CourseDto
    {
        public int CourseId { get; set; }

        public required string CourseTitle { get; set; }

        public required string CourseDescription { get; set; }

        public string? ThumbnailPath { get; set; }
    }
}