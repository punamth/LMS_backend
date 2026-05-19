using LMS.Application.Features.Lessons.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LMS.Application.Features.Lessons.Commands
{
    public class CreateLessonCommand : IRequest<LessonDto>
    {
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public string LessonTitle { get; set; } = string.Empty;
        public string ContentText { get; set; } = string.Empty;

        // file upload
        public IFormFile? VideoFile { get; set; }

        // optional fallback for VideoPath (used only if controller sets it manually)
        public string? VideoPath { get; set; }
    }
}
