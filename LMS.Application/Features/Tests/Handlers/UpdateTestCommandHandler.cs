using LMS.Application.Features.Tests.Commands;
using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using MediatR;

namespace LMS.Application.Features.Tests.Handlers
{
    public class UpdateTestCommandHandler : IRequestHandler<UpdateTestCommand, bool>
    {
        private readonly ITestRepository _testRepository;

        public UpdateTestCommandHandler(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<bool> Handle(UpdateTestCommand request, CancellationToken cancellationToken)
        {
            var test = await _testRepository.GetByIdAsync(request.TestId);
            if (test == null)
                return false;

            test.CourseId = request.CourseId;
            test.QuestionText = request.QuestionText;
            test.Options = request.Options;        // ✅ direct List<string> assignment
            test.CorrectAnswer = request.CorrectAnswer;

            await _testRepository.UpdateAsync(test);
            return true;
        }
    }
}
