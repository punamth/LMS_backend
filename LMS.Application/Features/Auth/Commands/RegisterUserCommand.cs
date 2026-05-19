using MediatR;
using LMS.Application.Features.Auth.DTOs;

namespace LMS.Application.Features.Auth.Commands
{
    public class RegisterUserCommand : IRequest<UserDto>
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
