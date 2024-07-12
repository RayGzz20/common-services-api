using Moq;
using AppCommonServices.Application.Faq.Common;
using AppCommonServices.Application.Faq.Queries;
using domainFaq = AppCommonServices.Domain.Faq.Entities;
using AppCommonServices.Test.Utilities;
using AutoFixture;
using ErrorOr;
using AppCommonServices.Domain.Faq;

namespace AppCommonServices.Test.Application.Faq
{
    [TestClass]
    public class GetAllFaqQueryHandlerTest : UnitTestBase
    {
        private readonly Mock<IFaqRepository> _repositoryMock;

        public GetAllFaqQueryHandlerTest()
        {
            _repositoryMock = new();
        }

        [TestMethod]
        public async Task HandleGetAllFaqWhenDataIsValidShouldResultOK()
        {
            // Prepare
            var query = new GetAllFaqsQuery();

            var list = Task.FromResult(_fixture.CreateMany<domainFaq.Faq>().ToList());

            _repositoryMock.Setup(f => f.GetAllActive()).Returns(list);

            var handler = new GetAllFaqsQueryHandler(_repositoryMock.Object);

            // Execute
            var result = await handler.Handle(query, default);

            // Verify
            Assert.IsFalse(result.IsError, "result is Error");
            Assert.IsInstanceOfType<List<FaqResponse>>(result.Value, 
                "result is not instance of List<FaqResponse>");
            Assert.IsTrue(result.Value.Count > 0, "result not have elements");
        }

        [TestMethod]
        public void HandleGetAllFaqWhenRepositoryIsNotValidShouldResultError()
        {
            // Prepare
            var query = new GetAllFaqsQuery();

            // Execute
            try
            {
                var handler = new GetAllFaqsQueryHandler(null!);
            }
            catch (Exception ex)
            {
                // Verify
                Assert.IsInstanceOfType<ArgumentNullException>
                    (ex, "exception is not instance of ArgumentNullException");
                Assert.IsTrue(ex.Message.Contains("faqRepository"),
                    "exception is not provocate by a faqRepository null");
            }
        }

        [TestMethod]
        public async Task HandleGetAllFaqWhenDataIsValidAndResponseIsEmptyShouldResultOK()
        {
            // Prepare
            var query = new GetAllFaqsQuery();

            var list = Task.FromResult(new List<domainFaq.Faq>());

            _repositoryMock.Setup(f => f.GetAllActive()).Returns(list);

            var handler = new GetAllFaqsQueryHandler(_repositoryMock.Object);

            // Execute
            var result = await handler.Handle(query, default);

            // Verify
            Assert.IsFalse(result.IsError, "result is Error");
            Assert.IsInstanceOfType<List<FaqResponse>>(result.Value, 
                "result is not instance of List<FaqResponse>");
            Assert.IsTrue(result.Value.Count == 0, "result have elements");
        }

        [TestMethod]
        public async Task HandleGetAllFaqWhenRepositoryThrowsExceptionShouldResultError()
        {
            // Prepare
            var query = new GetAllFaqsQuery();

            _repositoryMock.Setup(f => f.GetAllActive()).ThrowsAsync(new Exception("Repository exception"));

            var handler = new GetAllFaqsQueryHandler(_repositoryMock.Object);

            try
            {
                //Execute
                var result = await handler.Handle(query, CancellationToken.None);

                // Verify
                Assert.IsTrue(result.IsError, "result is not Error");
                Assert.IsNull(result.Value, "result should be null");
                Assert.AreEqual(ErrorType.Unexpected, result.FirstError.Type, "result error type is not Unexpected");
                Assert.IsFalse(string.IsNullOrEmpty(result.FirstError.Description), "result does not contain error message");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex}");
            }
        }
    }
}