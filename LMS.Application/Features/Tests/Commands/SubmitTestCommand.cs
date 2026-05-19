using MediatR;

namespace LMS.Application.Features.Tests.Commands
{
    public class SubmitTestCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int TestId { get; set; }
        public required string SelectedAnswer { get; set; }
    }
}
