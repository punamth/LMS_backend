using MediatR;
using LMS.Application.Features.Tests.Commands;
using LMS.Application.Interfaces;
using LMS.Domain.Entities;

namespace LMS.Application.Features.Tests.Handlers
{
    public class SubmitTestHandler : IRequestHandler<SubmitTestCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubmitTestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(SubmitTestCommand request, CancellationToken cancellationToken)
        {
            var test = await _unitOfWork.Tests.GetByIdAsync(request.TestId);
            if (test == null)
                throw new Exception("Test not found.");

            var userExists = await _unitOfWork.Users.GetByIdAsync(request.UserId);
            if (userExists == null)
                throw new Exception("User not found.");

            var testAttempt = new TestAttempt
            {
                UserId = request.UserId,
                TestId = request.TestId,
                SelectedAnswer = request.SelectedAnswer,
                AttemptedAt = DateTime.UtcNow,
                Score = test.CorrectAnswer == request.SelectedAnswer ? 1 : 0
            };

            await _unitOfWork.TestAttempts.AddAsync(testAttempt);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
