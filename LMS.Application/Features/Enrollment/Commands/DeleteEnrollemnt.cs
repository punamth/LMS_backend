using MediatR;

namespace LMS.Application.Features.Enrollment.Commands
{
    public class DeleteEnrollmentCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}
