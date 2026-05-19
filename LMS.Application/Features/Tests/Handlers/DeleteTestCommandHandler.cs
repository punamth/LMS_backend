using LMS.Application.Features.Tests.Commands;
using LMS.Application.Interfaces;
using MediatR;

namespace LMS.Application.Features.Tests.Handlers
{
    public class DeleteTestCommandHandler : IRequestHandler<DeleteTestCommand, bool>
    {
        private readonly ITestRepository _testRepository;

        public DeleteTestCommandHandler(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<bool> Handle(DeleteTestCommand request, CancellationToken cancellationToken)
        {
            var test = await _testRepository.GetByIdAsync(request.TestId);

            if (test == null)
                return false;

            await _testRepository.DeleteAsync(test);

            return true;
        }
    }
}
