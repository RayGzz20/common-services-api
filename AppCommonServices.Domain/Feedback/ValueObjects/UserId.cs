namespace AppCommonServices.Domain.Feedback.ValueObjects
{
    public partial record UserId
    {
        private UserId(string value) => Value = value;

        public static UserId? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 50)
            {
                return null;
            }

            return new UserId(value);
        }

        public string Value { get; init; }
    }
}
