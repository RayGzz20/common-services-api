using ErrorOr;

namespace AppCommonServices.Domain.Faq.Errors
{
    public static class AnswerErrors
    {
        public static Error NotFound => Error.NotFound(
            code: "Answer.NotFound",
            description: "Answer with given ID does not exist");

        public static Error DescriptionnBadFormat => Error.Validation(
            code: "Answer.Description",
            description: "Description is invalid. The description must have a value between 1 and 1000.");

        public static Error PositionBadFormat => Error.NotFound(
            code: "Answer.Position",
            description: "The position must be an integer greater than 0.");
    }
}
