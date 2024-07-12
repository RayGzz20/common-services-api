using AppCommonServices.Domain.Common;

namespace AppCommonServices.Domain.Faq.Events
{
    public record class FaqDomainEvent(Guid Id) : IDomainEvent;
}
