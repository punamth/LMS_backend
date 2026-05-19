using LMS.Application.Features.Auth.DTOs;
using MediatR;

namespace LMS.Application.Features.Auth.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserDto>>
    {
    }
}