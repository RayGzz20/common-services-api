using AppCommonServices.Domain.Common.ValueObjects;

namespace AppCommonServices.Domain.Common;

public abstract class AggregateRoot : AuditableEntity
{

    private readonly List<IDomainEvent> _domainEvents = new();

    public ICollection<IDomainEvent> GetDomainEvents() => _domainEvents;

    protected AggregateRoot(Id id) : base(id)
    {
        Id = id;
    }

    protected void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    protected AggregateRoot() : base() { }
}