using MediatR;

namespace LMS.Application.Features.Auth.Commands
{
    public class LoginUserCommand : IRequest<string> // returns JWT token
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string UserRole { get; set; }
    }
}
