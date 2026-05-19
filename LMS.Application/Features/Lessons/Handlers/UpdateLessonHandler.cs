using AutoMapper;
using LMS.Application.Features.Lessons.Commands;
using LMS.Application.Features.Lessons.DTOs;
using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace LMS.Application.Features.Lessons.Handlers
{
    public class UpdateLessonHandler : IRequestHandler<UpdateLessonCommand, LessonDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public UpdateLessonHandler(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        public async Task<LessonDto> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await _unitOfWork.Lessons.GetByIdAsync(request.LessonId);
            if (lesson == null)
                return null!;

            // Update fields if provided
            if (!string.IsNullOrWhiteSpace(request.LessonTitle))
                lesson.LessonTitle = request.LessonTitle;

            if (!string.IsNullOrWhiteSpace(request.ContentText))
                lesson.ContentText = request.ContentText;

            // Handle video file upload
            if (request.VideoFile != null && request.VideoFile.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}_{request.VideoFile.FileName}";
                var savePath = Path.Combine(_env.WebRootPath, "uploads", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await request.VideoFile.CopyToAsync(stream, cancellationToken);
                }

                lesson.VideoPath = $"/uploads/{fileName}";
            }
            else if (!string.IsNullOrWhiteSpace(request.VideoPath))
            {
                lesson.VideoPath = request.VideoPath;
            }

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<LessonDto>(lesson);
        }
    }
}
