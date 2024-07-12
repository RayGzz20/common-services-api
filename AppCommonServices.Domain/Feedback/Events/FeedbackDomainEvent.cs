using AppCommonServices.Domain.Common;

namespace AppCommonServices.Domain.Feedback.Events
{
    public record class FeedbackDomainEvent(Guid Id) : IDomainEvent;
}
