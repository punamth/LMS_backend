using LMS.Application.Features.Courses.Commands;
using LMS.Application.Interfaces;
using MediatR;

namespace LMS.Application.Features.Courses.Handlers
{
    public class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCourseHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            // Get the course by Id
            var course = await _unitOfWork.Courses.GetByIdAsync(request.Id);

            if (course == null)
                return false; // Course not found

            // Delete the course asynchronously
            await _unitOfWork.Courses.DeleteAsync(course);

            // Save changes
            await _unitOfWork.CompleteAsync();

            return true; // Successfully deleted
        }
    }
}
