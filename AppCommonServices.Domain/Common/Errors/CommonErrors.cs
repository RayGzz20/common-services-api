using ErrorOr;

namespace AppCommonServices.Domain.Common.Errors
{
    public static class CommonErrors
    {
        public static Error InvalidId => Error.Validation(
            code: "InvalidId",
            description: "ID is invalid");

        public static Error NotFound => Error.NotFound(
            code: "NotFound",
            description: "object with given ID does not exist");
    }
}
