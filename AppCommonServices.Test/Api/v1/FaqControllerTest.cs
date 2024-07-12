using AppCommonServices.Application.Faq.Queries;
using AppCommonServices.Test.Utilities;
using AppCommonServices.WebAPI.Common.Errors;
using AppCommonServices.WebAPI.Controllers.v1;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AppCommonServices.Test.Api.v1
{
    [TestClass]
    public class FaqControllerTest : UnitTestBase
    {
        private readonly Mock<ISender> _mediatorMock;

        public FaqControllerTest()
        {
            _mediatorMock = new Mock<ISender>();
        }

        [TestMethod]
        public async Task GetAllWhenSenderIsValidShouldBeResultOK()
        {
            // Prepare
            var _controller = new FaqController(_mediatorMock.Object);

            // Execute
            var result = await _controller.GetAll();

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.IsInstanceOfType<OkObjectResult>(result, "result is not an OkObjectResult");
            Assert.IsTrue(((OkObjectResult)result).StatusCode == 200, "result is not 200");
        }

        [TestMethod]
        public void GetAllWhenSenderIsNotValidShouldBeResultOK()
        {
            // Prepare

            // Execute
            try
            {
                var _controller = new FaqController(null);
            }
            catch (Exception ex)
            {
                // Verify
                Assert.IsInstanceOfType<ArgumentNullException>
                    (ex, "exception is not instance of ArgumentNullException");
                Assert.IsTrue(ex.Message.Contains("mediator"),
                    "exception is not provocate by a mediator null");
            }
        }

        [TestMethod]
        public async Task GetAllWhenFaqInternalServerErrorReturnsStatus500InternalServerError()
        {

            // Prepare
            var errorList = new List<ErrorOr.Error> { AppCommonServices.Domain.Faq.Errors.FaqErrors.UnexpectedError };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllFaqsQuery>(), default)).ReturnsAsync(errorList);

            var httpContext = new DefaultHttpContext();
            httpContext.Items[HttpContextItemKeys.Errors] = new List<Error>();

            var controller = new FaqController(_mediatorMock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext
                }
            };

            // Execute
            var result = await controller.GetAll();

            // Verify
            var problemResult = result as ObjectResult;
            Assert.IsNotNull(problemResult);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, problemResult.StatusCode);

            var problemDetails = problemResult.Value as ProblemDetails;
            Assert.IsNotNull(problemDetails);
            Assert.AreEqual("An unexpected error has occurred.", problemDetails.Title);
        }

        [TestMethod]
        public async Task GetByIdWhenSenderIsValidShouldBeResultOK()
        {
            // Prepare
            var _controller = new FaqController(_mediatorMock.Object);

            var id = Guid.NewGuid();

            // Execute
            var result = await _controller.GetById(id);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.IsInstanceOfType<OkObjectResult>(result, "result is not an OkObjectResult");
            Assert.IsTrue(((OkObjectResult)result).StatusCode == 200, "result is not 200");
        }

        [TestMethod]
        public async Task GetByIdWhenFaqNotFoundReturnsStatus404NotFound()
        {

            // Prepare
            var id = Guid.NewGuid();
            ErrorOr.Error toCreate = AppCommonServices.Domain.Faq.Errors.FaqErrors.NotFound;

            var errorList = new List<ErrorOr.Error> { toCreate };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetByIdFaqsQuery>(), default)).ReturnsAsync(errorList);

            var httpContext = new DefaultHttpContext();
            httpContext.Items[HttpContextItemKeys.Errors] = new List<Error>();

            var controller = new FaqController(_mediatorMock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext
                }
            };

            // Execute
            var result = await controller.GetById(id);

            // Verify
            var problemResult = result as ObjectResult;
            Assert.IsNotNull(problemResult);
            Assert.AreEqual(StatusCodes.Status404NotFound, problemResult.StatusCode);

            var problemDetails = problemResult.Value as ProblemDetails;
            Assert.IsNotNull(problemDetails);
            Assert.AreEqual("FAQ with given ID does not exist", problemDetails.Title);
        }

        [TestMethod]
        public async Task GetByIdWhenFaqInternalServerErrorReturnsStatus500InternalServerError()
        {

            // Prepare
            var id = Guid.NewGuid();

            var errorList = new List<ErrorOr.Error> { AppCommonServices.Domain.Faq.Errors.FaqErrors.UnexpectedError };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetByIdFaqsQuery>(), default))
                         .ReturnsAsync(errorList);

            var httpContext = new DefaultHttpContext();
            httpContext.Items[HttpContextItemKeys.Errors] = new List<Error>();

            var controller = new FaqController(_mediatorMock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext
                }
            };

            // Execute
            var result = await controller.GetById(id);

            // Verify
            var problemResult = result as ObjectResult;
            Assert.IsNotNull(problemResult);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, problemResult.StatusCode);

            var problemDetails = problemResult.Value as ProblemDetails;
            Assert.IsNotNull(problemDetails);
            Assert.AreEqual("An unexpected error has occurred.", problemDetails.Title);
        }
    }
}
