using AppCommonServices.Application.Feedback.Commands;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mime;

namespace AppCommonServices.WebAPI.Controllers.v1
{
    /// <summary>
    /// This endpoint allows you to work with feedbacks.
    /// </summary>
    [ApiVersion(1.0)]
    public class FeedbackController : BaseApiController
    {
        private readonly ISender _mediator;

        public FeedbackController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// records the user's feedback
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Identificator key for the feedback created</returns>
        /// <response code="201">The feedback created was created.</response>
        /// <response code="404">No feedback was created.</response>
        /// <response code="500">Internal server error.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Consumes(MediaTypeNames.Application.Json)]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateFeedback([FromBody] CreateFeedbackCommand command)
        {
            var createResult = await _mediator.Send(command);

            return createResult.Match(
                prom => Created("", prom),
                errors => Problem(errors)
            );
        }
    }
}
