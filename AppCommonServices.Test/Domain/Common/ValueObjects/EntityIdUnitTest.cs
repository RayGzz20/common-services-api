using AppCommonServices.Domain.Common.ValueObjects;
using ErrorOr;

namespace AppCommonServices.Test.Domain.Common.ValueObjects
{
    [TestClass]
    public class EntityIdUnitTest
    {
        [TestMethod]
        public void IdCreateUniqueShouldResultOK()
        {
            // Prepare
            var expectedId = Guid.NewGuid();

            // Execute
            var result = Id.CreateUnique();

            // Verify
            Assert.IsNotNull(result, "Result is null");
            Assert.IsInstanceOfType(result, typeof(Id), "Result is not of type Id");
            Assert.AreNotEqual(expectedId, result.Value, "Result value is not unique");
        }

        [TestMethod]
        public void IdCreateWithGuidShouldReturnIdWithSameGuid()
        {
            // Arrange
            var expectedGuid = Guid.NewGuid();

            // Act
            var result = Id.Create(expectedGuid);

            // Assert
            Assert.IsNotNull(result, "Result is null");
            Assert.IsInstanceOfType(result, typeof(Id), "Result is not of type Id");
            Assert.AreEqual(expectedGuid, result.Value, "Result value is not the same as the provided Guid");
        }

        [TestMethod]
        public void IdCreateWithStringWhenValidStringShouldReturnId()
        {
            // Arrange
            var expectedGuid = Guid.NewGuid();

            // Act
            var result = Id.Create(expectedGuid.ToString());

            // Assert
            Assert.IsNotNull(result, "Result is null");
            Assert.IsInstanceOfType(result, typeof(ErrorOr<Id>), "Result is not of type ErrorOr<Id>");
            Assert.IsFalse(result.IsError, "Result is an error");
            Assert.AreEqual(expectedGuid, result.Value.Value, "Result value is not the same as the provided Guid");
        }

        [TestMethod]
        public void IdCreateWithStringWhenInvalidStringShouldReturnError()
        {
            // Arrange
            var invalidString = "invalid_guid";

            // Act
            var result = Id.Create(invalidString);

            // Assert
            Assert.IsNotNull(result, "Result is null");
            Assert.IsInstanceOfType(result, typeof(ErrorOr<Id>), "Result is not of type ErrorOr<Id>");
            Assert.IsTrue(result.IsError, "Result is not an error");
            Assert.AreEqual(ErrorType.Validation, result.FirstError.Type, "result error type is not of Validation");
        }

        [TestMethod]
        public void FaqIdCreateUniqueShouldResultOK()
        {
            // Prepare


            // Execute
            Id faqId = Id.CreateUnique();

            // Verify
            Assert.IsNotNull(faqId, "faqId is null");
            Assert.IsInstanceOfType<Id>(faqId, "faqId is not of type FaqId");
            Assert.IsTrue(faqId.Value.ToString().Length > 0, "faqId does not have an Id with value");
            Assert.IsInstanceOfType<Guid>(faqId.Value, "the faqId Id is not of type Guid");
        }

        [TestMethod]
        public void FaqIdCreateWithGuidValidShouldResultOK()
        {
            // Prepare
            var id = Guid.NewGuid();

            // Execute
            Id faqId = Id.Create(id);

            // Verify
            Assert.IsNotNull(faqId, "faqId is null");
            Assert.IsInstanceOfType<Id>(faqId, "faqId is not of type FaqId");
            Assert.IsTrue(faqId.Value.ToString().Length > 0, "faqId does not have an Id with value");
            Assert.IsInstanceOfType<Guid>(faqId.Value, "the faqId Id is not of type Guid");
        }

        [TestMethod]
        public void FaqIdCreateWithStringGuidValidShouldResultOK()
        {
            // Prepare
            string myGuid = Guid.NewGuid().ToString();

            // Execute
            ErrorOr<Id> faqId = Id.Create(myGuid);

            // Verify
            Assert.IsNotNull(faqId, "faqId is null");
            Assert.IsFalse(faqId.IsError, "faqId is not valid");
            Assert.IsInstanceOfType<Id>(faqId.Value, "faqId is not of type FaqId");
            Assert.IsTrue(faqId.Value.Value.ToString().Length > 0, "faqId does not have an Id with value");
            Assert.IsInstanceOfType<Guid>(faqId.Value.Value, "the faqId Id is not of type Guid");
        }

        [TestMethod]
        public void FaqIdCreateWithStringNotValidShouldResultOK()
        {
            // Prepare
            string myGuid = "XXXX";

            // Execute
            ErrorOr<Id> faqId = Id.Create(myGuid);

            // Verify
            Assert.IsNotNull(faqId, "faqId is not null");
            Assert.IsTrue(faqId.IsError, "faqId has no error and should have one ");
            Assert.IsInstanceOfType<ErrorOr<Id>>(faqId, "faqId is not of type ErrorOr");
            Assert.IsNull(faqId.Value, "faqId does not register errors");
            Assert.IsNotNull(faqId.Errors, "faqId does not register errors");
            Assert.IsTrue(faqId.Errors.Count > 0, "faqId does not register errors");
        }

        [TestMethod]
        public void FaqIdCreateWithStringEmptyShouldResultOK()
        {
            // Prepare
            string myGuid = "";

            // Execute
            ErrorOr<Id> faqId = Id.Create(myGuid);

            // Verify
            Assert.IsNotNull(faqId, "faqId is not null");
            Assert.IsTrue(faqId.IsError, "faqId has no error and should have one ");
            Assert.IsInstanceOfType<ErrorOr<Id>>(faqId, "faqId is not of type ErrorOr");
            Assert.IsNull(faqId.Value, "faqId does not register errors");
            Assert.IsNotNull(faqId.Errors, "faqId does not register errors");
            Assert.IsTrue(faqId.Errors.Count > 0, "faqId does not register errors");
        }
    }
}