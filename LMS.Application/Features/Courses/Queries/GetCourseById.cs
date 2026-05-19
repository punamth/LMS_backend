using MediatR;
using LMS.Application.Features.Courses.DTOs;

namespace LMS.Application.Features.Courses.Queries
{
    public class GetCourseByIdQuery : IRequest<CourseDto?>
    {
        public int Id { get; set; }
    }
}
