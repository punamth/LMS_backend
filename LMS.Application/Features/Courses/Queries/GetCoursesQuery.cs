using MediatR;
using LMS.Application.Features.Courses.DTOs;
using System.Collections.Generic;

namespace LMS.Application.Features.Courses.Queries
{
    public class GetCoursesQuery : IRequest<IEnumerable<CourseDto>>
    {
    }
}
