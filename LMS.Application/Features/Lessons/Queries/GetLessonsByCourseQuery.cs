using MediatR;
using LMS.Application.Features.Lessons.DTOs;
using System.Collections.Generic;

namespace LMS.Application.Features.Lessons.Queries
{
    public class GetLessonsByCourseQuery : IRequest<IEnumerable<LessonDto>>
    {
        public int CourseId { get; set; }
    }
}
