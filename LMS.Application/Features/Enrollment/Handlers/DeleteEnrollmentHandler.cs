using MediatR;
using LMS.Application.Features.Enrollment.Commands;
using LMS.Application.Interfaces;

namespace LMS.Application.Features.Enrollment.Handlers
{
    public class DeleteEnrollmentHandler : IRequestHandler<DeleteEnrollmentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEnrollmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var enrollment = (await _unitOfWork.Enrollments
                .FindAsync(e => e.UserId == request.UserId && e.CourseId == request.CourseId))
                .FirstOrDefault();

            if (enrollment == null)
                throw new Exception("Enrollment not found");

            // Correct: use DeleteAsync and await it
            await _unitOfWork.Enrollments.DeleteAsync(enrollment);

            return true;
        }
    }
}
