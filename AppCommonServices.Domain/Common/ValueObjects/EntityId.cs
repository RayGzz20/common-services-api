using ErrorOr;

namespace AppCommonServices.Domain.Common.ValueObjects
{
    public class Id : ValueObject
    {
        public Guid Value { get; protected set; }

        public Id(Guid value)
        {
            Value = value;
        }

        public static Id CreateUnique()
        {
            return new Id(Guid.NewGuid());
        }

        public static Id Create(Guid value)
        {
            return new Id(value);
        }

        public static ErrorOr<Id> Create(string value)
        {
            return !Guid.TryParse(value, out var guid)
                ? (ErrorOr<Id>)Errors.CommonErrors.InvalidId
                : (ErrorOr<Id>)new Id(guid);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
