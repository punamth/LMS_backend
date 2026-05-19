using AutoMapper;
using LMS.Application.Features.Auth.DTOs;
using LMS.Application.Interfaces;
using MediatR;

namespace LMS.Application.Features.Auth.Queries
{
    public class GetAllUsersQueryHandler : IRequest<List<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users.ToList());
        }
    }
}