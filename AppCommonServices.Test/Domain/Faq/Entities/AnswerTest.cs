using AppCommonServices.Domain.Common.ValueObjects;
using AppCommonServices.Domain.Faq.Entities;
using AppCommonServices.Domain.Faq.ValueObjects;
using ErrorOr;

namespace AppCommonServices.Test.Domain.Faq.Entities
{
    [TestClass]
    public class AnswerTest
    {
        [TestMethod]
        public void AnswerCreateWhenAnswerIsValidShouldResultOK()
        {
            // Prepare
            AnswerName? name = AnswerName.Create("AnswerTest");
            Position? position = Position.Create(1);
            Id questionId = Id.CreateUnique();

            // Execute
            Answer? result = Answer.Create(name!, position!, true, questionId);

            // Verify
            Assert.IsNotNull(result, "Answer is null");
            Assert.IsInstanceOfType<Answer>(result, "result is not of type Answer");
            Assert.IsNotNull(result.Id, "result does not have an Id");
            Assert.IsInstanceOfType<Id>(result.Id, "the Id of result is not of type AnswerId");
            Assert.IsTrue(result.Id.Value.ToString().Length > 0, "result does not have an Id with value");
            Assert.IsInstanceOfType<Guid>(result.Id.Value, "the Id of result is not of type Guid");
        }

        [TestMethod]
        public void AnswerCreateWhenDescriptionIsNotValidShouldResultError()
        {
            // Prepare            
            Position? position = Position.Create(1);
            Id questionId = Id.CreateUnique();

            // Execute
            Answer? result = Answer.Create(null!, position!, true, questionId);

            // Verify
            Assert.IsNull(result, "result is null");
        }

        [TestMethod]
        public void AnswerCreateWhenPositionIsNotValidShouldResultError()
        {
            // Prepare            
            AnswerName? name = AnswerName.Create("AnswerTest");
            Id questionId = Id.CreateUnique();

            // Execute
            Answer? result = Answer.Create(name!, null!, true, questionId);

            // Verify
            Assert.IsNull(result, "result is null");
        }
        
        [TestMethod]
        public void AnswerCreateWhenFaqIdIsNotValidShouldResultError()
        {
            // Prepare            
            AnswerName? name = AnswerName.Create("AnswerTest");
            Position? position = Position.Create(1);

            // Execute
            Answer? result = Answer.Create(name!, position!, true, null!);

            // Verify
            Assert.IsNull(result, "result is null");
        }
        
        [TestMethod]
        public void AnswerNameCreateWhenNameIsValidShouldResultOK()
        {
            // Prepare
            var nameToCreate = "AnswerNameTest";

            // Execute
            AnswerName? name = AnswerName.Create(nameToCreate);

            // Verify
            Assert.IsNotNull(name, "AnswerName is null");
            Assert.IsTrue(name.Value == nameToCreate, "name created is not the same as the one provided for its creation");
        }

        [TestMethod]
        public void AnswerNameCreateWhenNameIsNullShouldResultNull()
        {
            // Prepare            

            // Execute
            AnswerName? name = AnswerName.Create(null!);

            // Verify
            Assert.IsNull(name, "AnswerName is not null");
        }

        [TestMethod]
        public void AnswerNameCreateWhenNameIsShortShouldResultNull()
        {
            // Prepare            
            var nameToCreate = "F";

            // Execute
            AnswerName? name = AnswerName.Create(nameToCreate);

            // Verify
            Assert.IsNull(name, "AnswerName is not null");
        }

        [TestMethod]
        public void AnswerNameCreateWhenNameIsEmptyShouldResultNull()
        {
            // Prepare            
            var nameToCreate = "";

            // Execute
            AnswerName? name = AnswerName.Create(nameToCreate);

            // Verify
            Assert.IsNull(name, "AnswerName is not null");
        }

        [TestMethod]
        public void AnswerNameCreateWhenNameIsTooLongShouldResultNull()
        {
            // Prepare            
            var nameToCreate = new string('e', 1001); ;

            // Execute
            AnswerName? name = AnswerName.Create(nameToCreate);

            // Verify
            Assert.IsNull(name, "AnswerName is not null");
        }

        [TestMethod]
        public void PositionCreateWhenPositionIsValidShouldResultOK()
        {
            // Prepare
            int positionToCreate = 1;

            // Execute
            Position? position = Position.Create(positionToCreate);

            // Verify
            Assert.IsNotNull(position, "Position is null");
            Assert.IsTrue(position.Value == positionToCreate, "created position is not equal to the one provided for its creation");
        }

        [TestMethod]
        public void PositionCreateWhenPositionIsNotValidShouldResultNull()
        {
            // Prepare
            int positionToCreate = 0;

            // Execute
            Position? position = Position.Create(positionToCreate);

            // Verify
            Assert.IsNull(position, "Position is null");
        }

        [TestMethod]
        public void AnswerIdCreateUniqueShouldResultOK()
        {
            // Prepare


            // Execute
            Id answerId = Id.CreateUnique();

            // Verify
            Assert.IsNotNull(answerId, "answerId is null");
            Assert.IsInstanceOfType<Id>(answerId, "answerId is not of type AnswerId");
            Assert.IsTrue(answerId.Value.ToString().Length > 0, "answerId does not have an Id with value");
            Assert.IsInstanceOfType<Guid>(answerId.Value, "the Id of answerId is not of type Guid");
        }

        [TestMethod]
        public void AnswerIdCreateWithGuidValidShouldResultOK()
        {
            // Prepare
            var id = Guid.NewGuid();

            // Execute
            Id answerId = Id.Create(id);

            // Verify
            Assert.IsNotNull(answerId, "answerId is null");
            Assert.IsInstanceOfType<Id>(answerId, "answerId is not of type AnswerId");
            Assert.IsTrue(answerId.Value.ToString().Length > 0, "answerId does not have an Id with value");
            Assert.IsInstanceOfType<Guid>(answerId.Value, "the Id of answerId is not of type Guid");
        }

        [TestMethod]
        public void AnswerIdCreateWithStringGuidValidShouldResultOK()
        {
            // Prepare
            string myGuid = Guid.NewGuid().ToString();

            // Execute
            ErrorOr<Id> answerId = Id.Create(myGuid);

            // Verify
            Assert.IsNotNull(answerId, "answerId is null");
            Assert.IsFalse(answerId.IsError, "answerId is not valid");
            Assert.IsInstanceOfType<Id>(answerId.Value, "answerId is not of type AnswerId");
            Assert.IsTrue(answerId.Value.Value.ToString().Length > 0, "answerId does not have an Id with value");
            Assert.IsInstanceOfType<Guid>(answerId.Value.Value, "the Id of answerId is not of type Guid");
        }

        [TestMethod]
        public void AnswerIdCreateWithStringNotValidShouldResultOK()
        {
            // Prepare
            string myGuid = "XXXX";

            // Execute
            ErrorOr<Id> answerId = Id.Create(myGuid);

            // Verify
            Assert.IsNotNull(answerId, "answerId is not null");
            Assert.IsTrue(answerId.IsError, "answerId has no error and should have one ");
            Assert.IsInstanceOfType<ErrorOr<Id>>(answerId, "answerId is not of type ErrorOr");
            Assert.IsNull(answerId.Value, "answerId does not register errors");
            Assert.IsNotNull(answerId.Errors, "answerId does not register errors");
            Assert.IsTrue(answerId.Errors.Count > 0, "answerId does not register errors");
        }

        [TestMethod]
        public void AnswerIdCreateWithStringEmptyShouldResultOK()
        {
            // Prepare
            string myGuid = "";

            // Execute
            ErrorOr<Id> answerId = Id.Create(myGuid);

            // Verify
            Assert.IsNotNull(answerId, "answerId is not null");
            Assert.IsTrue(answerId.IsError, "answerId has no error and should have one ");
            Assert.IsInstanceOfType<ErrorOr<Id>>(answerId, "answerId is not of type ErrorOr");
            Assert.IsNull(answerId.Value, "answerId does not register errors");
            Assert.IsNotNull(answerId.Errors, "answerId does not register errors");
            Assert.IsTrue(answerId.Errors.Count > 0, "answerId does not register errors");
        }
    }
}
