using ErrorOr;

namespace AppCommonServices.Domain.Faq.Errors
{
    public static class FaqErrors
    {
        public static Error NotFound => Error.NotFound(
            code: "Faq.NotFound",
            description: "FAQ with given ID does not exist");

        public static Error NameBadFormat => Error.Validation(
            code: "Faq.Name",
            description: "Name is invalid. The name must have a value between 1 and 50.");

        public static Error PositionBadFormat => Error.NotFound(
            code: "Faq.Position",
            description: "The position must be an integer greater than 0.");

        public static Error UnexpectedError => Error.Unexpected(
            code: "Faq.UnexpectedError");
    }
}
