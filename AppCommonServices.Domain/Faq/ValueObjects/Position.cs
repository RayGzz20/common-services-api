namespace AppCommonServices.Domain.Faq.ValueObjects
{
    public partial record Position
    {
        private Position(int value) => Value = value;

        public static Position? Create(int value)
        {
            if (value < 1)
            {
                return null;
            }

            return new Position(value);
        }

        public int Value { get; init; }
    }
}
