using MediatR;
using LMS.Application.Features.Courses.DTOs;
using LMS.Application.Features.Courses.Queries;
using LMS.Application.Interfaces;
using AutoMapper;

namespace LMS.Application.Features.Courses.Handlers
{
    public class GetCoursesHandler : IRequestHandler<GetCoursesQuery, IEnumerable<CourseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCoursesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }
    }
}
