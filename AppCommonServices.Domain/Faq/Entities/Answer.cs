using AppCommonServices.Domain.Common;
using AppCommonServices.Domain.Common.ValueObjects;
using AppCommonServices.Domain.Faq.ValueObjects;

namespace AppCommonServices.Domain.Faq.Entities
{
    public class Answer : AuditableEntity
    {
        public AnswerName Description { get; private set; }

        public Position Position { get; private set; }

        public bool IsActive { get; private set; }

        public Id QuestionId { get; private set; }

        private Answer(
            Id id,
            AnswerName description, 
            Position position, 
            bool isActive,
            Id questionId
            ) 
            : base(id)
        {
            Description = description;
            Position = position;
            IsActive = isActive;
            QuestionId = questionId;
        }

        public static Answer? Create(
            AnswerName description,
            Position position,
            bool isActive,
            Id questionId)
        {
            if (description is null || position is null || questionId is null)
            {
                return null;
            }

            return new Answer(
                Id.CreateUnique(),
                description,
                position,
                isActive,
                questionId);
        }

#pragma warning disable CS8618
        private Answer() : base() { }
#pragma warning restore CS8618

    }
}
