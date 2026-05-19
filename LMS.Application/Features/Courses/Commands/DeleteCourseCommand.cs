using MediatR;

namespace LMS.Application.Features.Courses.Commands
{
    public class DeleteCourseCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
