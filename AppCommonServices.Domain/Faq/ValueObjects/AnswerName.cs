namespace AppCommonServices.Domain.Faq.ValueObjects
{
    public partial record AnswerName
    {
        private AnswerName(string value) => Value = value;

        public static AnswerName? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 1000)
            {
                return null;
            }

            return new AnswerName(value);
        }

        public string Value { get; init; }
    }
}
