using MediatR;
using LMS.Application.Features.Lessons.Commands;
using LMS.Application.Features.Lessons.DTOs;
using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace LMS.Application.Features.Lessons.Handlers
{
    public class CreateLessonHandler : IRequestHandler<CreateLessonCommand, LessonDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CreateLessonHandler(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        public async Task<LessonDto> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            string? videoPath = null;

            // --- FILE UPLOAD HANDLING ---
            if (request.VideoFile != null && request.VideoFile.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}_{request.VideoFile.FileName}";
                var savePath = Path.Combine(_env.WebRootPath, "videos", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await request.VideoFile.CopyToAsync(stream, cancellationToken);
                }

                videoPath = $"/videos/{fileName}";
            }
            else
            {
                // fallback (in case controller sets VideoPath manually)
                videoPath = request.VideoPath;
            }

            // --- CREATE LESSON ENTITY ---
            var lesson = new Lesson
            {
                CourseId = request.CourseId,
                LessonTitle = request.LessonTitle,
                ContentText = request.ContentText,
                VideoPath = videoPath
            };

            await _unitOfWork.Lessons.AddAsync(lesson);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<LessonDto>(lesson);
        }
    }
}
