namespace AppCommonServices.Domain.Feedback.ValueObjects
{
    public partial record Comments
    {
        private Comments(string value) => Value = value;

        public static Comments? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 850)
            {
                return null;
            }

            return new Comments(value);

        }

        public string Value { get; init; }
    }
}