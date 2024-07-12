using AppCommonServices.Application.Faq.Common;
using AppCommonServices.Application.Faq.Queries;
using AppCommonServices.Domain.Common.ValueObjects;
using AppCommonServices.Domain.Faq;
using AppCommonServices.Domain.Faq.Entities;
using AppCommonServices.Domain.Faq.ValueObjects;
using AppCommonServices.Test.Utilities;
using AutoFixture;
using ErrorOr;
using Moq;
using domainFaqEntities = AppCommonServices.Domain.Faq.Entities;

namespace AppCommonServices.Test.Application.Faq
{
    [TestClass]
    public class GetByIdFaqQueryHandlerTest : UnitTestBase
    {
        private readonly Mock<IFaqRepository> _repositoryMock;

        public GetByIdFaqQueryHandlerTest()
        {
            _repositoryMock = new();
        }

        [TestMethod]
        public async Task HandleGetByIdFaqWhenDataIsValidShouldResultOK()
        {
            // Prepare GetByIdFaqsQuery
            var query = new GetByIdFaqsQuery(Guid.NewGuid());

            var fixtureCreated = _fixture.Create<domainFaqEntities.Faq>();

            _repositoryMock.Setup(f => f.GetByIdAsync(It.IsAny<Id>()))
                           .ReturnsAsync(fixtureCreated);

            var handler = new GetByIdFaqsQueryHandler(_repositoryMock.Object);

            // Execute and Verify
            var result = await handler.Handle(query, CancellationToken.None);

            // Verify
            Assert.IsFalse(result.IsError, "result is Error");
            Assert.IsNotNull(result.Value, "result is null");
            Assert.IsInstanceOfType(result.Value, typeof(FaqDetailResponse),
                "result is not instance of Faq");
            Assert.IsTrue(result.Value.Questions.Count > 0, "result in the list of questions not have elements");
            Assert.IsTrue(result.Value.Questions[0].Answers.Count > 0, "result in the list of Answer not have elements");
        }

        [TestMethod]
        public async Task HandleGetByIdFaqWhenDataIsValidAndHasNoQuestionsShouldResultOK()
        {
            // Prepare
            var id = Guid.NewGuid();
            var query = new GetByIdFaqsQuery(id);

            var toCreate = domainFaqEntities.Faq.Create(
                FaqName.Create("Main")!,
                UrlImage.Create("UrlImage")!,
                FaqPosition.Create(1)!,
                true,
                new List<Question>()
            );

            _repositoryMock.Setup(f => f.GetByIdAsync(It.IsAny<Id>()))
                           .ReturnsAsync(toCreate);

            var handler = new GetByIdFaqsQueryHandler(_repositoryMock.Object);

            // Execute
            var result = await handler.Handle(query, CancellationToken.None);

            // Verify
            Assert.IsFalse(result.IsError, "result is Error");
            Assert.IsNotNull(result.Value, "result is null");
            Assert.IsInstanceOfType(result.Value, typeof(FaqDetailResponse), "result is not instance of Faq");
            Assert.AreEqual(0, result.Value.Questions.Count, "result has questions");
        }

        [TestMethod]
        public async Task HandleGetByIdFaqWhenDataIsValidAndHasNoAnswersShouldResultOK()
        {
            // Prepare
            var id = Guid.NewGuid();
            var query = new GetByIdFaqsQuery(id);

            var question = Question.Create(
                QuestionName.Create("desc")!,
                Position.Create(1)!,
                true,
                Id.Create(Guid.NewGuid()),
                new List<Answer>()
            );

            var questions = new List<Question> { question! };

            // Creamos una seccion ayuda con una pregunta sin respuestas
            var toCreate = domainFaqEntities.Faq.Create(
                FaqName.Create("Main")!,
                UrlImage.Create("UrlImage")!,
                FaqPosition.Create(1)!,
                true,
                questions
            );

            _repositoryMock.Setup(f => f.GetByIdAsync(It.IsAny<Id>()))
                           .ReturnsAsync(toCreate);

            var handler = new GetByIdFaqsQueryHandler(_repositoryMock.Object);

            // Execute
            var result = await handler.Handle(query, CancellationToken.None);

            // Verify
            Assert.IsFalse(result.IsError, "result is Error");
            Assert.IsNotNull(result.Value, "result is null");
            Assert.IsInstanceOfType(result.Value, typeof(FaqDetailResponse), "result is not instance of Faq");
            Assert.AreEqual(1, result.Value.Questions.Count, "result has no questions");
            Assert.AreEqual(0, result.Value.Questions[0].Answers.Count, "result has answers");
        }

        [TestMethod]
        public async Task HandleGetByIdFaqWhenIdIsInvalidShouldResultError()
        {
            // Prepare
            var invalidId = Guid.Empty; // ID inválido
            var query = new GetByIdFaqsQuery(invalidId);

            // Execute
            var handler = new GetByIdFaqsQueryHandler(_repositoryMock.Object);
            var result = await handler.Handle(query, CancellationToken.None);

            // Verify
            Assert.IsTrue(result.IsError, "result is not Error as expected");
            Assert.IsNull(result.Value, "result value should be null");
            Assert.AreEqual(ErrorType.NotFound, result.FirstError.Type, "result error type is not NotFound");
            Assert.IsFalse(string.IsNullOrEmpty(result.FirstError.Description), "result does not contain error message");
        }

        [TestMethod]
        public async Task HandleGetByIdFaqWhenRepositoryIsNotValidShouldResultError()
        {
            // Prepare
            var id = Guid.NewGuid();
            var query = new GetByIdFaqsQuery(id);

            // Configuración del Mock del repositorio para devolver null
            _repositoryMock.Setup(f => f.GetByIdAsync(It.IsAny<Id>()))
                           .ReturnsAsync((domainFaqEntities.Faq)null);

            var handler = new GetByIdFaqsQueryHandler(_repositoryMock.Object);

            try
            {
                //Execute
                var result = await handler.Handle(query, CancellationToken.None);

                // Verify
                Assert.IsTrue(result.IsError, "result is not Error");
                Assert.IsNull(result.Value, "result is not null");
                Assert.AreEqual(ErrorType.NotFound, result.FirstError.Type, "result error type is not NotFound");
                Assert.IsFalse(string.IsNullOrEmpty(result.FirstError.Description), "result does not contain error message");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex}");
            }
        }

        [TestMethod]
        public async Task HandleGetByIdFaqWhenRepositoryThrowsExceptionShouldResultError()
        {
            // Prepare
            var validId = Guid.NewGuid(); // ID válido
            var query = new GetByIdFaqsQuery(validId);

            var repositoryMock = new Mock<IFaqRepository>();
            repositoryMock.Setup(f => f.GetByIdAsync(It.IsAny<Id>())).ThrowsAsync(new Exception("Repository exception"));

            var handler = new GetByIdFaqsQueryHandler(repositoryMock.Object);

            try
            {
                // Execute
                var result = await handler.Handle(query, CancellationToken.None);

                // Verify
                Assert.IsTrue(result.IsError, "result is not Error as expected");
                Assert.IsNull(result.Value, "result value should be null");
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

