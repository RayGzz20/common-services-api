using Microsoft.AspNetCore.Mvc;

namespace AppCommonServices.Test.Utilities
{
    public class ProblemDetailsForTest : ProblemDetails
    {
        public ProblemDetailsForTest(IDictionary<string, object?> errors) : base()
        {
            Extensions = errors;
        }
    }
}
