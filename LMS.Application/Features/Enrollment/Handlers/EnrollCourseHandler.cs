using MediatR;
using LMS.Application.Features.Enrollment.Commands;
using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using EnrollmentEntity = LMS.Domain.Entities.Enrollment;

namespace LMS.Application.Features.Enrollment.Handlers
{
    public class EnrollCourseHandler : IRequestHandler<EnrollCourseCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnrollCourseHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EnrollCourseCommand request, CancellationToken cancellationToken)
        {
            // Check if already enrolled
            var existing = (await _unitOfWork.Enrollments.FindAsync(
                e => e.UserId == request.UserId && e.CourseId == request.CourseId))
                .FirstOrDefault();

            if (existing != null)
                throw new Exception("User is already enrolled in this course");

            var enrollment = new EnrollmentEntity
            {
                UserId = request.UserId,
                CourseId = request.CourseId,
                EnrolledAt = DateTime.UtcNow
            };

            await _unitOfWork.Enrollments.AddAsync(enrollment);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}

