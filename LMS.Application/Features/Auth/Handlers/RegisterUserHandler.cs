using AutoMapper;
using MediatR;
using LMS.Application.Features.Auth.DTOs;
using LMS.Application.Features.Auth.Commands;
using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace LMS.Application.Features.Auth.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // Check if user exists
            var existing = (await _unitOfWork.Users.FindAsync(u => u.Email == request.Email)).FirstOrDefault();
            if (existing != null)
                throw new Exception("Email already registered");

            // Hash password
            using var sha256 = SHA256.Create();
            var hashedPassword = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(request.Password)));

            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                PasswordHash = hashedPassword,
                UserRole = "Student"
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<UserDto>(user);
        }
    }
}
