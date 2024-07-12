namespace AppCommonServices.Domain.Faq.ValueObjects
{
    public partial record FaqPosition
    {
        private FaqPosition(int value) => Value = value;

        public static FaqPosition? Create(int value)
        {
            if (value < 1)
            {
                return null;
            }

            return new FaqPosition(value);
        }

        public int Value { get; init; }
    }
}
