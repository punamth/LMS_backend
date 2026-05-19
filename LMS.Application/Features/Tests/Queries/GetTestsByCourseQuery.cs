using MediatR;
using LMS.Application.Features.Tests.DTOs;
using System.Collections.Generic;

namespace LMS.Application.Features.Tests.Queries
{
    public class GetTestsByCourseQuery : IRequest<IEnumerable<TestDto>>
    {
        public int CourseId { get; set; }
    }
}
