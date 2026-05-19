using MediatR;
using LMS.Application.Features.Lessons.Commands;
using LMS.Application.Interfaces;

namespace LMS.Application.Features.Lessons.Handlers
{
    public class DeleteLessonHandler : IRequestHandler<DeleteLessonCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLessonHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await _unitOfWork.Lessons.GetByIdAsync(request.LessonId);
            if (lesson == null)
                return false;

            // Use DeleteAsync from your GenericRepository
            await _unitOfWork.Lessons.DeleteAsync(lesson);

            // Commit changes if your unit of work requires it (or it's already done in DeleteAsync)
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
