using ErrorOr;

namespace AppCommonServices.Domain.Faq.Errors
{
    public static class QuestionErrors
    {
        public static Error NotFound => Error.NotFound(
            code: "Question.NotFound",
            description: "Question with given ID does not exist");

        public static Error DescriptionnBadFormat => Error.Validation(
            code: "Question.Description",
            description: "Description is invalid. The description must have a value between 1 and 500.");

        public static Error PositionBadFormat => Error.NotFound(
            code: "Question.Position",
            description: "The position must be an integer greater than 0.");
    }
}
