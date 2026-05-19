using AutoMapper;
using LMS.Application.Features.Courses.DTOs;
using LMS.Application.Features.Courses.Queries;
using LMS.Application.Interfaces;
using MediatR;

namespace LMS.Application.Features.Courses.Handlers
{
    public class GetCourseByIdHandler : IRequestHandler<GetCourseByIdQuery, CourseDto?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCourseByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CourseDto?> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(request.Id);
            if (course == null) return null;

            return _mapper.Map<CourseDto>(course);
        }
    }
}
