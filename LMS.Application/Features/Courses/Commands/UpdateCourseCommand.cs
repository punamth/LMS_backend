using LMS.Application.Features.Courses.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LMS.Application.Features.Courses.Commands
{
    public class UpdateCourseCommand : IRequest<CourseDto>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public IFormFile? Thumbnail { get; set; }
    }
}