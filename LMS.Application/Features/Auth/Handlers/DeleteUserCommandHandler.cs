using LMS.Application.Interfaces;
using MediatR;

namespace LMS.Application.Features.Auth.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.UserId);
            if (user == null)
                return false;

            await _unitOfWork.Users.DeleteAsync(user);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}