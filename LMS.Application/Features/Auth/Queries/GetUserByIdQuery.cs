using LMS.Application.Features.Auth.DTOs;
using MediatR;

namespace LMS.Application.Features.Auth.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto?>
    {
        public int Id { get; set; }
    }
}