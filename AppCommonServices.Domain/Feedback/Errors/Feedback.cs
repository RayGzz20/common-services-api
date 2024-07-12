
using ErrorOr;

namespace AppCommonServices.Domain.Feedback.Errors
{
    public class Feedback
    {
        public static Error NotCreated => Error.Validation(
                code: "Feedback.NotCreated",
                description: "Feedback is not valid.");

        public static Error InvalidComments => Error.Validation(
            code: "Feedback.InvalidComments",
            description: "Comments is not valid.");

        public static Error InvalidUserId => Error.Validation(
            code: "Feedback.InvalidUserId",
            description: "UserId is not valid.");

        public static Error UnexpectedError => Error.Unexpected(
            code: "Feedback.UnexpectedError");
    }
}
