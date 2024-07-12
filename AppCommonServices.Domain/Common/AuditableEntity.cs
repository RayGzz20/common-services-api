using AppCommonServices.Domain.Common.ValueObjects;

namespace AppCommonServices.Domain.Common
{
    public abstract class AuditableEntity : Entity
    {
        public Audit Audit { get; protected set; }

        protected AuditableEntity(Id id) : base(id)
        {
            Audit = Audit.Create(DateTimeOffset.Now, "", null, null);
        }

#pragma warning disable CS8618
        public AuditableEntity()
        {
            Audit = Audit.Create(DateTimeOffset.Now, "", null, null);
        }
#pragma warning restore CS8618

    }
}
