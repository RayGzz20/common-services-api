using AppCommonServices.Application.Feedback.Commands;
using AppCommonServices.WebAPI.Controllers.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AppCommonServices.Test.Api.v1
{
    [TestClass]
    public class FeedbackControllerTest
    {
        private readonly Mock<ISender> _mediatorMock;

        public FeedbackControllerTest()
        {
            _mediatorMock = new Mock<ISender>();
        }

        [TestMethod]
        public async Task ControllerCreateWhenSenderIsValidShouldBeResultOK()
        {
            // Prepare
            var _controller = new FeedbackController(_mediatorMock.Object);

            CreateFeedbackCommand command = new CreateFeedbackCommand(
                "1548796",
                "Prueba 1"
            );

            // Execute
            var result = await _controller.CreateFeedback(command);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.IsInstanceOfType<CreatedResult>(result, "result is not an CreatedResult");
            Assert.IsTrue(((CreatedResult)result).StatusCode == 201, "result is not 201");
        }

        [TestMethod]
        public void ControllerCreateWhenSenderIsNotValidShouldBeResultError()
        {
            // Prepare

            // Execute
            try
            {
                var _controller = new FeedbackController(null!);
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

    }
}
