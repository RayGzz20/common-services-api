using AppCommonServices.Domain.Common;
using AppCommonServices.Domain.Common.ValueObjects;
using AppCommonServices.Domain.Feedback.ValueObjects;

namespace AppCommonServices.Domain.Feedback.Entities
{
    public sealed class Feedback : AggregateRoot
    {
        public UserId UserId { get; set; }

        public Comments Comments { get; private set; }

        private Feedback(
            Id id, 
            UserId userId, 
            Comments comments
        ) : base(id)
        {
            UserId = userId;
            Comments = comments;
        }

        public static Feedback? Create(
            UserId userId,
            Comments comments
        )
        {
            if (userId is null || comments is null)
            {
                return null;
            }

            return new Feedback(
                Id.CreateUnique(),
                userId,
                comments
            );
        }

#pragma warning disable CS8618
        private Feedback() : base() { }
#pragma warning restore CS8618
    }
}
