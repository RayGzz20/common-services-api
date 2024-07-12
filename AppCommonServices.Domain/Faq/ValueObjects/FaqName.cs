namespace AppCommonServices.Domain.Faq.ValueObjects
{
    public partial record FaqName
    {
        private FaqName(string value) => Value = value;

        public static FaqName? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 50)
            {
                return null;
            }

            return new FaqName(value);
        }

        public string Value { get; init; }
    }
}
