using MediatR;
using LMS.Application.Features.Lessons.DTOs;
using System.Collections.Generic;

namespace LMS.Application.Features.Progress.Queries
{
    public class GetUserProgressQuery : IRequest<IEnumerable<LessonDto>>
    {
        public int UserId { get; set; }
    }
}
