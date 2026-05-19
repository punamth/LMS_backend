using LMS.Application.Features.Tests.Commands;
using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using MediatR;

namespace LMS.Application.Features.Tests.Handlers
{
    public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand, int>
    {
        private readonly ITestRepository _testRepository;

        public CreateTestCommandHandler(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<int> Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
            var test = new Test
            {
                CourseId = request.CourseId,
                QuestionText = request.QuestionText,
                Options = request.Options,    
                CorrectAnswer = request.CorrectAnswer
            };

            await _testRepository.AddAsync(test);

            return test.TestId;
        }
    }
 }
