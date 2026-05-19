using LMS.Application.Features.Lessons.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LMS.Application.Features.Lessons.Commands
{
    public class UpdateLessonCommand : IRequest<LessonDto>
    {
        public int LessonId { get; set; } 
        public string? LessonTitle { get; set; }
        public string? ContentText { get; set; }

        // Optional video upload
        public IFormFile? VideoFile { get; set; }

        // Optional fallback for VideoPath
        public string? VideoPath { get; set; }
    }
}