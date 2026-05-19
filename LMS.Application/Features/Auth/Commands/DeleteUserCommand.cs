using MediatR;

namespace LMS.Application.Features.Auth.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int UserId { get; set; }
    }
}