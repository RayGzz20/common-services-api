using AppCommonServices.Domain.Common.ValueObjects;

namespace AppCommonServices.Domain.Common
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Id Id { get; protected set; }

        protected Entity(Id id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity entity && Id.Equals(entity.Id);
        }

        public bool Equals(Entity? other)
        {
            return Equals((object?)other);
        }

        public static bool operator ==(Entity left, Entity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

#pragma warning disable CS8618
        protected Entity()
        {
        }
#pragma warning restore CS8618
    }

}
