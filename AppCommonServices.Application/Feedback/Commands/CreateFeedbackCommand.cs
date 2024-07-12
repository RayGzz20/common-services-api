
namespace AppCommonServices.Application.Feedback.Commands
{
    public record CreateFeedbackCommand(    
        string UserId,
        string Comments
    ) : IRequest<ErrorOr<Guid>>;
}
