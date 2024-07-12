namespace AppCommonServices.Domain.Faq.ValueObjects
{
    public partial record QuestionName
    {
        private QuestionName(string value) => Value = value;

        public static QuestionName? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 500)
            {
                return null;
            }

            return new QuestionName(value);
        }

        public string Value { get; init; }
    }
}
