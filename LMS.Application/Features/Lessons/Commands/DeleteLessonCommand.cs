using MediatR;

namespace LMS.Application.Features.Lessons.Commands
{
    public class DeleteLessonCommand : IRequest<bool>
    {
        public int LessonId { get; set; } 
    }
}
