namespace LMS.Application.Features.Tests.DTOs
{
    public class TestDto
    {
        public int TestId { get; set; }

        public int CourseId { get; set; }

        public required string QuestionText { get; set; }

        public required List<string> Options { get; set; } = new();

        public required string CorrectAnswer { get; set; }
    }
}