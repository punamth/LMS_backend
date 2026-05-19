using LMS.Application.Features.Courses.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LMS.Application.Features.Courses.Commands
{ 
    public class CreateCourseCommand : IRequest<CourseDto>
    {
        public required string CourseTitle { get; set; }
        public required string CourseDescription { get; set; }

        public IFormFile? ThumbnailPath { get; set; }
    }
}
