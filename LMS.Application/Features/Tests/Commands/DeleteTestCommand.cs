using MediatR;

namespace LMS.Application.Features.Tests.Commands
{
    public class DeleteTestCommand : IRequest<bool>
    {
        public int TestId { get; set; }
    }
}
