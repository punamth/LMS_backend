using MediatR;
using LMS.Application.Features.Progress.Commands;
using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using ProgressEntity = LMS.Domain.Entities.Progress;

namespace LMS.Application.Features.Progress.Handlers
{
    public class UpdateProgressHandler : IRequestHandler<UpdateProgressCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProgressHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateProgressCommand request, CancellationToken cancellationToken)
        {
            var progress = new ProgressEntity
            {
                UserId = request.UserId,
                LessonId = request.LessonId,
                CompletedAt = DateTime.UtcNow
            };

            await _unitOfWork.Progress.AddAsync(progress);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}