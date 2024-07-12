using AppCommonServices.Domain.Common;
using AppCommonServices.Domain.Feedback;
using E = AppCommonServices.Domain.Feedback.Entities;
using DE = AppCommonServices.Domain.Feedback.Errors;
using AppCommonServices.Domain.Feedback.ValueObjects;

namespace AppCommonServices.Application.Feedback.Commands
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, ErrorOr<Guid>>
    {
        private readonly IFeedbackRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFeedbackCommandHandler(IFeedbackRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Guid>> Handle(CreateFeedbackCommand command, CancellationToken cancellationToken)
        {
            if (UserId.Create(command.UserId) is not UserId userId)
                return DE.Feedback.InvalidUserId;

            if (Comments.Create(command.Comments) is not Comments comments)
                return DE.Feedback.InvalidComments;

            var feedback = E.Feedback.Create(userId!, comments!);

            if (feedback is null)
                return DE.Feedback.NotCreated;

            _repository.AddAsync(feedback);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return feedback.Id.Value;
        }
    }
}
