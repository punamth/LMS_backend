using MediatR;
using LMS.Application.Features.Courses.DTOs;
using LMS.Application.Features.Courses.Commands;
using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace LMS.Application.Features.Courses.Handlers
{
    public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, CourseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CreateCourseHandler(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        public async Task<CourseDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            string? thumbnailPath = null;

            if (request.ThumbnailPath != null && request.ThumbnailPath.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}_{request.ThumbnailPath.FileName}";
                var savePath = Path.Combine(_env.WebRootPath, "uploads", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await request.ThumbnailPath.CopyToAsync(stream, cancellationToken);
                }

                thumbnailPath = $"/uploads/{fileName}";
            }

            var course = new Course
            {
                CourseTitle = request.CourseTitle,
                CourseDescription = request.CourseDescription,
                ThumbnailPath = thumbnailPath
            };

            await _unitOfWork.Courses.AddAsync(course);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<CourseDto>(course);
        }
    }
}
