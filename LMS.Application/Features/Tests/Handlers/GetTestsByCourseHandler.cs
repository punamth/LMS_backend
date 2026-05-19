using MediatR;
using LMS.Application.Features.Tests.Queries;
using LMS.Application.Features.Tests.DTOs;
using LMS.Application.Interfaces;
using AutoMapper;

namespace LMS.Application.Features.Tests.Handlers
{
	public class GetTestsByCourseHandler : IRequestHandler<GetTestsByCourseQuery, IEnumerable<TestDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetTestsByCourseHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IEnumerable<TestDto>> Handle(GetTestsByCourseQuery request, CancellationToken cancellationToken)
		{
			var tests = await _unitOfWork.Tests.FindAsync(t => t.CourseId == request.CourseId);
			return _mapper.Map<IEnumerable<TestDto>>(tests);
		}
	}
}
