using AppCommonServices.Application.Faq.Common;
using AppCommonServices.Application.Faq.Queries;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mime;

namespace AppCommonServices.WebAPI.Controllers.v1
{
    /// <summary>
    /// This endpoint allows you to work with frequently asked questions.
    /// </summary>
    [ApiVersion(1.0)]
    public class FaqController : BaseApiController
    {
        private readonly ISender _mediator;

        public FaqController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Bring all the category information.
        /// </summary>
        /// <remarks>
        /// Returns the FAQ category corresponding.
        /// </remarks>
        /// <response code="200">The requested FAQ category is returned.</response>
        /// <response code="500">Internal server error.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FaqDetailResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]        
        public async Task<IActionResult> GetAll()
        {
            var faqsResult = await _mediator.Send(new GetAllFaqsQuery());

            return faqsResult.Match(
                faqs => Ok(faqs),
                errors => Problem(errors)
            );
        }

        /// <summary>
        /// Retrieves a frequently asked questions (FAQ) category by its identifier.
        /// </summary>
        /// <remarks>
        /// Returns the FAQ category corresponding to the provided identifier.
        /// </remarks>
        /// <param name="id" example="00000000-0000-0000-0000-000000000000">ID of the FAQ category.</param>
        /// <response code="200">The requested FAQ category is returned.</response>
        /// <response code="404">No FAQ category was found with the specified ID.</response>
        /// <response code="500">Internal server error.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FaqDetailResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var promResult = await _mediator.Send(new GetByIdFaqsQuery(id));

            return promResult.Match(
                prom => Ok(prom),
                errors => Problem(errors)
            );
        }
    }
}
