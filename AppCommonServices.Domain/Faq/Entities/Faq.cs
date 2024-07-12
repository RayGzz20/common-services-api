using AppCommonServices.Domain.Common;
using AppCommonServices.Domain.Common.ValueObjects;
using AppCommonServices.Domain.Faq.ValueObjects;

namespace AppCommonServices.Domain.Faq.Entities
{
    public sealed class Faq : AggregateRoot
    {
        private readonly List<Question> _questions = new();

        public FaqName Name { get; private set; }

        public UrlImage UrlImage { get; private set; }

        public FaqPosition Position { get; private set; }

        public bool IsActive { get; private set; }

        public IReadOnlyCollection<Question> Questions => 
            _questions.AsReadOnly();

        private Faq(
            Id id,
            FaqName name,
            UrlImage urlImage,
            FaqPosition position, 
            bool isActive,
            List<Question> questions) 
            : base(id)
        {
            Name = name;
            UrlImage = urlImage;
            Position = position;
            IsActive = isActive;
            _questions = questions;
        }

        public static Faq? Create(
            FaqName name,
            UrlImage urlImage,
            FaqPosition position,
            bool isActive,
            List<Question>? questions = null) 
        {
            if (name is null || urlImage is null || position is null)
            {
                return null;
            }

            return new Faq(
                Id.CreateUnique(),
                name,
                urlImage,
                position, 
                isActive,
                questions ?? new ()); 
        }

#pragma warning disable CS8618
        private Faq() : base()
        {
        }
#pragma warning restore CS8618
    }
}
