using MediatR;

namespace LMS.Application.Features.Progress.Commands
{
    public class UpdateProgressCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int LessonId { get; set; }
    }
}
