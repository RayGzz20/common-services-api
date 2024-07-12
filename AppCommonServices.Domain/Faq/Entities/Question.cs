using AppCommonServices.Domain.Common;
using AppCommonServices.Domain.Common.ValueObjects;
using AppCommonServices.Domain.Faq.ValueObjects;

namespace AppCommonServices.Domain.Faq.Entities
{
    public class Question : AuditableEntity
    {
        private readonly List<Answer> _answers;

        public QuestionName Description { get; private set; }

        public Position Position { get; private set; }

        public bool IsActive { get; private set; }

        public Id? FaqId { get; private set; }

        public IReadOnlyCollection<Answer> Answers => _answers.AsReadOnly();

        private Question(
            Id id,
            QuestionName description, 
            Position position, 
            bool isActive,
            List<Answer> answers,
            Id faqId
            )
            : base(id)
        {
            Description = description;
            Position = position;
            IsActive = isActive;
            _answers = answers;
            FaqId = faqId;
        }

        public static Question? Create(
            QuestionName description,
            Position position,
            bool isActive,
            Id faqId,
            List<Answer>? answers = null)
        {
            if (description is null || position is null || faqId is null)
            {
                return null;
            }

            return new Question(
                Id.CreateUnique(),
                description, 
                position, 
                isActive,
                answers ?? new(),
                faqId);
        }

#pragma warning disable CS8618
        private Question() : base() { }
#pragma warning restore CS8618


    }
}
