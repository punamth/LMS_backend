using MediatR;
using LMS.Application.Features.Courses.DTOs;
using LMS.Application.Features.Courses.Commands;
using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace LMS.Application.Features.Courses.Handlers
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, CourseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public UpdateCourseHandler(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        public async Task<CourseDto> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(request.Id);
            if (course == null)
                throw new Exception("Course not found.");

            // Update basic properties
            course.CourseTitle = request.Title;
            course.CourseDescription = request.Description;

            // Handle thumbnail upload if a new file is provided
            if (request.Thumbnail != null && request.Thumbnail.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}_{request.Thumbnail.FileName}";
                var savePath = Path.Combine(_env.WebRootPath, "uploads", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await request.Thumbnail.CopyToAsync(stream, cancellationToken);
                }

                // Update entity with new path
                course.ThumbnailPath = $"/uploads/{fileName}";
            }

            await _unitOfWork.Courses.UpdateAsync(course);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<CourseDto>(course);
        }
    }
}
