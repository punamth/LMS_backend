using MediatR;

namespace LMS.Application.Features.Tests.Commands
{
    public class CreateTestCommand : IRequest<int> 
    {
        public int CourseId { get; set; }
        public int TestId { get; set; }
        public required string QuestionText { get; set; }
        public List<string> Options { get; set; } = new();
        public required string CorrectAnswer { get; set; }
    }
}
