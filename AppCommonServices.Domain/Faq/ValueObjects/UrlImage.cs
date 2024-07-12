namespace AppCommonServices.Domain.Faq.ValueObjects
{
    public partial record UrlImage
    {
        private UrlImage(string value) => Value = value;

        public static UrlImage? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 255)
            {
                return null;
            }

            return new UrlImage(value);
        }

        public string Value { get; init; }
    }
}
