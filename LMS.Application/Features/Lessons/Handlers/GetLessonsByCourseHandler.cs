using MediatR;
using LMS.Application.Features.Lessons.DTOs;
using LMS.Application.Features.Lessons.Queries;
using LMS.Application.Interfaces;
using AutoMapper;

namespace LMS.Application.Features.Lessons.Handlers
{
    public class GetLessonsByCourseHandler : IRequestHandler<GetLessonsByCourseQuery, IEnumerable<LessonDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLessonsByCourseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LessonDto>> Handle(GetLessonsByCourseQuery request, CancellationToken cancellationToken)
        {
            var lessons = await _unitOfWork.Lessons.FindAsync(l => l.CourseId == request.CourseId);
            return _mapper.Map<IEnumerable<LessonDto>>(lessons);
        }
    }
}
