using MediatR;
using LMS.Application.Features.Progress.Queries;
using LMS.Application.Features.Lessons.DTOs;
using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using AutoMapper;
using System.Linq;

namespace LMS.Application.Features.Progress.Handlers
{
    public class GetUserProgressHandler : IRequestHandler<GetUserProgressQuery, IEnumerable<LessonDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserProgressHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LessonDto>> Handle(GetUserProgressQuery request, CancellationToken cancellationToken)
        {
            var progressList = await _unitOfWork.Progress.FindAsync(p => p.UserId == request.UserId);
            var lessonIds = progressList.Select(p => p.LessonId).Distinct();
            var lessons = new List<Lesson>();

            foreach (var lessonId in lessonIds)
            {
                var lesson = await _unitOfWork.Lessons.GetByIdAsync(lessonId);
                if (lesson != null)
                {
                    lessons.Add(lesson);
                }
            }

            return _mapper.Map<IEnumerable<LessonDto>>(lessons);
        }
    }
 }
