namespace AppCommonServices.Domain.Common.ValueObjects
{
    public class Audit : ValueObject
    {
        public DateTimeOffset CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public Audit(DateTimeOffset createdOn, string createdBy, DateTimeOffset? updatedOn, string? updatedBy)
        {
            CreatedOn = createdOn;
            CreatedBy = createdBy;
            UpdatedOn = updatedOn;
            UpdatedBy = updatedBy;
        }

        public static Audit Create(DateTimeOffset createdOn, string createdBy, DateTimeOffset? updatedOn, string? updatedBy)
        {
            // TODO: Enforce invariants
            return new Audit(createdOn, createdBy, updatedOn, updatedBy);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return CreatedOn;
            yield return CreatedBy;
            yield return UpdatedOn;
            yield return UpdatedBy;
        }
    }
}
