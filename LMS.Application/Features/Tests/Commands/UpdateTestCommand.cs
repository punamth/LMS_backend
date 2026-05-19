using MediatR;

namespace LMS.Application.Features.Tests.Commands
{
    public class UpdateTestCommand : IRequest<bool>
    {
        public int TestId { get; set; }
        public int CourseId { get; set; }
        public required string QuestionText { get; set; }
        public List<string> Options { get; set; } = new();
        public required string CorrectAnswer { get; set; }
    }
}
