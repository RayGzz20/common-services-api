using AutoFixture;
using ErrorOr;
using Moq;
using AppCommonServices.Domain.Common;
using AppCommonServices.Domain.Feedback;
using AppCommonServices.Test.Utilities;
using AppCommonServices.Application.Feedback.Commands;

namespace AppCommonServices.Test.Application.Feedback
{
    [TestClass]
    public class CreateFeedbackCommandHandlerTest : UnitTestBase
    {
        private readonly Mock<IFeedbackRepository> _repositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public CreateFeedbackCommandHandlerTest()
        {
            _repositoryMock = new();
            _unitOfWorkMock = new();
        }

        [TestMethod]
        public void CreateFeedbackCommandWhenInjectionIsValidShouldResultOK()
        {
            // Prepare

            // Execute
            var handler = new CreateFeedbackCommandHandler(_repositoryMock.Object, _unitOfWorkMock.Object);

            // Verify
            Assert.IsNotNull(handler, "command is null");
            Assert.IsInstanceOfType<CreateFeedbackCommandHandler>(handler, "result is not an CreateFeedbackCommandHandler");
        }

        [TestMethod]
        public void CreateFeedbackCommandWhenRepositoryIsNotValidShouldResultError()
        {
            // Prepare

            // Execute
            try
            {
                var handler = new CreateFeedbackCommandHandler(null!, _unitOfWorkMock.Object);
            }
            catch (Exception ex)
            {
                // Verify
                Assert.IsInstanceOfType<ArgumentNullException>
                   (ex, "exception is not instance of ArgumentNullException");
                Assert.IsTrue(ex.Message.Contains("repository"),
                    "exception is not provocate by a repository null");
            }
        }

        [TestMethod]
        public void CreateFeedbackCommandWhenUnitOfWorkIsNotValidShouldResultError()
        {
            // Prepare

            // Execute
            try
            {
                var handler = new CreateFeedbackCommandHandler(_repositoryMock.Object, null!);
            }
            catch (Exception ex)
            {
                // Verify
                Assert.IsInstanceOfType<ArgumentNullException>
                   (ex, "exception is not instance of ArgumentNullException");
                Assert.IsTrue(ex.Message.Contains("unitOfWork"),
                    "exception is not provocate by a unitOfWork null");
            }
        }

        [TestMethod]
        public async Task CreateFeedbackCommandWhenDataIsValidShouldResultOK()
        {
            // Prepare
            var command = new CreateFeedbackCommand(
                _fixture.Create<string>(),
                _fixture.Create<string>()
                );

            var handler = new CreateFeedbackCommandHandler(_repositoryMock.Object, _unitOfWorkMock.Object);

            // Execute
            var result = await handler.Handle(command, default);

            // Verify
            Assert.IsNotNull(handler, "handler is null");
            Assert.IsInstanceOfType<CreateFeedbackCommandHandler>(handler, "result is not an CreateFeedbackCommandHandler");
            Assert.IsFalse(result.IsError, "result is Error");
            Assert.IsNotNull(result.Value, "result is null");
            Assert.IsInstanceOfType(result.Value, typeof(Guid),
                "result is not instance of Unit");
        }

        [TestMethod]
        public async Task CreateFeedbackCommandWhenUserIdIsNullShouldResultError()
        {
            // Prepare
            var command = new CreateFeedbackCommand(
                null!,
                _fixture.Create<string>()
                );

            var handler = new CreateFeedbackCommandHandler(_repositoryMock.Object, _unitOfWorkMock.Object);

            // Execute
            var result = await handler.Handle(command, default);

            // Verify
            Assert.IsNotNull(handler, "handler is null");
            Assert.IsInstanceOfType<CreateFeedbackCommandHandler>(handler, "result is not an CreateFeedbackCommandHandler");
            Assert.IsTrue(result.IsError, "result is not an Error");
            Assert.IsTrue(result.Errors.Count > 0, "result has not Errors");
            Assert.IsInstanceOfType<Error>(result.FirstError, "result is not instance of Error");
            Assert.IsTrue(result.FirstError.Code == "Feedback.InvalidUserId", "result is not an Error of Feedback.InvalidUserId");
            Assert.IsTrue(result.FirstError.Type == ErrorType.Validation, "result is not a Validation Error");
        }

        [TestMethod]
        public async Task CreateFeedbackCommandWhenUserIdIsEmptyShouldResultError()
        {
            // Prepare
            var command = new CreateFeedbackCommand(
                "",
                _fixture.Create<string>()
                );

            var handler = new CreateFeedbackCommandHandler(_repositoryMock.Object, _unitOfWorkMock.Object);

            // Execute
            var result = await handler.Handle(command, default);

            // Verify
            Assert.IsNotNull(handler, "handler is null");
            Assert.IsInstanceOfType<CreateFeedbackCommandHandler>(handler, "result is not an CreateFeedbackCommandHandler");
            Assert.IsTrue(result.IsError, "result is not an Error");
            Assert.IsTrue(result.Errors.Count > 0, "result has not Errors");
            Assert.IsInstanceOfType<Error>(result.FirstError, "result is not instance of Error");
            Assert.IsTrue(result.FirstError.Code == "Feedback.InvalidUserId", "result is not an Error of Feedback.InvalidUserId");
            Assert.IsTrue(result.FirstError.Type == ErrorType.Validation, "result is not a Validation Error");
        }

        [TestMethod]
        public async Task CreateFeedbackCommandWhenUserIdIsNotLowerValidShouldResultError()
        {
            // Prepare
            var command = new CreateFeedbackCommand(
                "p",
                _fixture.Create<string>()
                );

            var handler = new CreateFeedbackCommandHandler(_repositoryMock.Object, _unitOfWorkMock.Object);

            // Execute
            var result = await handler.Handle(command, default);

            // Verify
            Assert.IsNotNull(handler, "handler is null");
            Assert.IsInstanceOfType<CreateFeedbackCommandHandler>(handler, "result is not an CreateFeedbackCommandHandler");
            Assert.IsTrue(result.IsError, "result is not an Error");
            Assert.IsTrue(result.Errors.Count > 0, "result has not Errors");
            Assert.IsInstanceOfType<Error>(result.FirstError, "result is not instance of Error");
            Assert.IsTrue(result.FirstError.Code == "Feedback.InvalidUserId", "result is not an Error of Feedback.InvalidUserId");
            Assert.IsTrue(result.FirstError.Type == ErrorType.Validation, "result is not a Validation Error");
        }

        [TestMethod]
        public async Task CreateFeedbackCommandWhenUserIdIsNotLargerValidShouldResultError()
        {
            // Prepare
            var command = new CreateFeedbackCommand(
                new string('p', 51),
                _fixture.Create<string>()
                );

            var handler = new CreateFeedbackCommandHandler(_repositoryMock.Object, _unitOfWorkMock.Object);

            // Execute
            var result = await handler.Handle(command, default);

            // Verify
            Assert.IsNotNull(handler, "handler is null");
            Assert.IsInstanceOfType<CreateFeedbackCommandHandler>(handler, "result is not an CreateFeedbackCommandHandler");
            Assert.IsTrue(result.IsError, "result is not an Error");
            Assert.IsTrue(result.Errors.Count > 0, "result has not Errors");
            Assert.IsInstanceOfType<Error>(result.FirstError, "result is not instance of Error");
            Assert.IsTrue(result.FirstError.Code == "Feedback.InvalidUserId", "result is not an Error of Feedback.InvalidUserId");
            Assert.IsTrue(result.FirstError.Type == ErrorType.Validation, "result is not a Validation Error");
        }

        [TestMethod]
        public async Task CreateFeedbackCommandWhenCommentsIsNullShouldResultError()
        {
            // Prepare
            var command = new CreateFeedbackCommand(
                _fixture.Create<string>(),
                null!
                );

            var handler = new CreateFeedbackCommandHandler(_repositoryMock.Object, _unitOfWorkMock.Object);

            // Execute
            var result = await handler.Handle(command, default);

            // Verify
            Assert.IsNotNull(handler, "handler is null");
            Assert.IsInstanceOfType<CreateFeedbackCommandHandler>(handler, "result is not an CreateFeedbackCommandHandler");
            Assert.IsTrue(result.IsError, "result is not an Error");
            Assert.IsTrue(result.Errors.Count > 0, "result has not Errors");
            Assert.IsInstanceOfType<Error>(result.FirstError, "result is not instance of Error");
            Assert.IsTrue(result.FirstError.Code == "Feedback.InvalidComments", "result is not an Error of Feedback.InvalidComments");
            Assert.IsTrue(result.FirstError.Type == ErrorType.Validation, "result is not a Validation Error");
        }

        [TestMethod]
        public async Task CreateFeedbackCommandWhenCommentsIsEmptyShouldResultError()
        {
            // Prepare
            var command = new CreateFeedbackCommand(
                _fixture.Create<string>(),
                ""
                );

            var handler = new CreateFeedbackCommandHandler(_repositoryMock.Object, _unitOfWorkMock.Object);

            // Execute
            var result = await handler.Handle(command, default);

            // Verify
            Assert.IsNotNull(handler, "handler is null");
            Assert.IsInstanceOfType<CreateFeedbackCommandHandler>(handler, "result is not an CreateFeedbackCommandHandler");
            Assert.IsTrue(result.IsError, "result is not an Error");
            Assert.IsTrue(result.Errors.Count > 0, "result has not Errors");
            Assert.IsInstanceOfType<Error>(result.FirstError, "result is not instance of Error");
            Assert.IsTrue(result.FirstError.Code == "Feedback.InvalidComments", "result is not an Error of Feedback.InvalidComments");
            Assert.IsTrue(result.FirstError.Type == ErrorType.Validation, "result is not a Validation Error");
        }

        [TestMethod]
        public async Task CreateFeedbackCommandWhenCommentsIsTooLowerShouldResultError()
        {
            // Prepare
            var command = new CreateFeedbackCommand(
                _fixture.Create<string>(),
                "p"
                );

            var handler = new CreateFeedbackCommandHandler(_repositoryMock.Object, _unitOfWorkMock.Object);

            // Execute
            var result = await handler.Handle(command, default);

            // Verify
            Assert.IsNotNull(handler, "handler is null");
            Assert.IsInstanceOfType<CreateFeedbackCommandHandler>(handler, "result is not an CreateFeedbackCommandHandler");
            Assert.IsTrue(result.IsError, "result is not an Error");
            Assert.IsTrue(result.Errors.Count > 0, "result has not Errors");
            Assert.IsInstanceOfType<Error>(result.FirstError, "result is not instance of Error");
            Assert.IsTrue(result.FirstError.Code == "Feedback.InvalidComments", "result is not an Error of Feedback.InvalidComments");
            Assert.IsTrue(result.FirstError.Type == ErrorType.Validation, "result is not a Validation Error");
        }

        [TestMethod]
        public async Task CreateFeedbackCommandWhenCommentsIsTooLargeShouldResultError()
        {
            // Prepare
            var command = new CreateFeedbackCommand(
                _fixture.Create<string>(),
                new string('p', 851)
                );

            var handler = new CreateFeedbackCommandHandler(_repositoryMock.Object, _unitOfWorkMock.Object);

            // Execute
            var result = await handler.Handle(command, default);

            // Verify
            Assert.IsNotNull(handler, "handler is null");
            Assert.IsInstanceOfType<CreateFeedbackCommandHandler>(handler, "result is not an CreateFeedbackCommandHandler");
            Assert.IsTrue(result.IsError, "result is not an Error");
            Assert.IsTrue(result.Errors.Count > 0, "result has not Errors");
            Assert.IsInstanceOfType<Error>(result.FirstError, "result is not instance of Error");
            Assert.IsTrue(result.FirstError.Code == "Feedback.InvalidComments", "result is not an Error of Feedback.InvalidComments");
            Assert.IsTrue(result.FirstError.Type == ErrorType.Validation, "result is not a Validation Error");
        }

    }
}
