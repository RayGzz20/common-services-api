using AppCommonServices.Domain.Common.ValueObjects;
using AppCommonServices.Domain.Faq.Entities;
using AppCommonServices.Domain.Faq.ValueObjects;
using ErrorOr;

namespace AppCommonServices.Test.Domain.Faq.Entities
{
    [TestClass]
    public class QuestionTest 
    {
        [TestMethod]
        public void QuestionCreateWhenQuestionIsValidShouldResultOK()
        {
            // Prepare
            QuestionName? name = QuestionName.Create("QuestionTest");
            Position? position = Position.Create(1);
            Id faqId = Id.CreateUnique();

            // Execute
            Question? result = Question.Create(name!, position!, true, faqId);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.IsInstanceOfType<Question>(result, "result is not Question");
            Assert.IsNotNull(result.Id, "result has no Id");
            Assert.IsInstanceOfType<Id>(result.Id, "result.Id is not an Id type");
            Assert.IsTrue(result.Id.Value.ToString().Length > 0, "result has an empty Id");
            Assert.IsInstanceOfType<Guid>(result.Id.Value, "result.Id is not an Guid type");
        }

        [TestMethod]
        public void QuestionCreateWhenDescriptionIsNotValidShouldResultError()
        {
            // Prepare            
            Position? position = Position.Create(1);
            Id faqId = Id.CreateUnique();

            // Execute
            Question? result = Question.Create(null!, position!, true, faqId);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void QuestionCreateWhenPositionIsNotValidShouldResultError()
        {
            // Prepare            
            QuestionName? name = QuestionName.Create("QuestionTest");
            Id faqId = Id.CreateUnique();

            // Execute
            Question? result = Question.Create(name!, null!, true, faqId);

            // Verify
            Assert.IsNull(result, "result is not null");
        }
        
        [TestMethod]
        public void QuestionCreateWhenFaqIdIsNotValidShouldResultError()
        {
            // Prepare            
            QuestionName? name = QuestionName.Create("QuestionTest");
            Position? position = Position.Create(1);

            // Execute
            Question? result = Question.Create(name!, position!, true, null!);

            // Verify
            Assert.IsNull(result, "result is not null");
        }
        
        [TestMethod]
        public void QuestionNameCreateWhenNameIsValidShouldResultOK()
        {
            // Prepare
            var nameToCreate = "QuestionNameTest";

            // Execute
            QuestionName? name = QuestionName.Create(nameToCreate);

            // Verify
            Assert.IsNotNull(name, "QuestionName is null");
            Assert.IsTrue(name.Value == nameToCreate, "name created is not the same as the one provided for its creation");
        }

        [TestMethod]
        public void QuestionNameCreateWhenNameIsNullShouldResultNull()
        {
            // Prepare            

            // Execute
            QuestionName? name = QuestionName.Create(null!);

            // Verify
            Assert.IsNull(name, "QuestionName is not null");
        }

        [TestMethod]
        public void QuestionNameCreateWhenNameIsShortShouldResultNull()
        {
            // Prepare            
            var nameToCreate = "F";

            // Execute
            QuestionName? name = QuestionName.Create(nameToCreate);

            // Verify
            Assert.IsNull(name, "QuestionName is not null");
        }

        [TestMethod]
        public void QuestionNameCreateWhenNameIsEmptyShouldResultNull()
        {
            // Prepare            
            var nameToCreate = "";

            // Execute
            QuestionName? name = QuestionName.Create(nameToCreate);

            // Verify
            Assert.IsNull(name, "QuestionName is not null");
        }

        [TestMethod]
        public void QuestionNameCreateWhenNameIsTooLongShouldResultNull()
        {
            // Prepare            
            var nameToCreate = new string('e', 501); ;

            // Execute
            QuestionName? name = QuestionName.Create(nameToCreate);

            // Verify
            Assert.IsNull(name, "QuestionName is not null");
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
            Assert.IsNull(position, "Position is not null");
        }

        [TestMethod]
        public void QuestionIdCreateUniqueShouldResultOK()
        {
            // Prepare
            

            // Execute
            Id questionId = Id.CreateUnique();

            // Verify
            Assert.IsNotNull(questionId, "questionId is null");
            Assert.IsInstanceOfType<Id>(questionId, "questionId is not of type QuestionId");
            Assert.IsTrue(questionId.Value.ToString().Length > 0, "questionId does not have an Id with value");
            Assert.IsInstanceOfType<Guid>(questionId.Value, "the Id of questionId is not of type Guid");
        }
        
        [TestMethod]
        public void QuestionIdCreateWithGuidValidShouldResultOK()
        {
            // Prepare
            var id = Guid.NewGuid();

            // Execute
            Id questionId = Id.Create(id);

            // Verify
            Assert.IsNotNull(questionId, "questionId is null");
            Assert.IsInstanceOfType<Id>(questionId, "questionId is not of type QuestionId");
            Assert.IsTrue(questionId.Value.ToString().Length > 0, "questionId does not have an Id with value");
            Assert.IsInstanceOfType<Guid>(questionId.Value, "the Id of questionId is not of type Guid");
        }

        [TestMethod]
        public void QuestionIdCreateWithStringGuidValidShouldResultOK()
        {
            // Prepare
            string myGuid = Guid.NewGuid().ToString();

            // Execute
            ErrorOr<Id> questionId = Id.Create(myGuid);

            // Verify
            Assert.IsNotNull(questionId, "questionId is null");
            Assert.IsFalse(questionId.IsError, "questionId is not valid");            
            Assert.IsInstanceOfType<Id>(questionId.Value, "questionId is not of type QuestionId");
            Assert.IsTrue(questionId.Value.Value.ToString().Length > 0, "questionId does not have an Id with value");
            Assert.IsInstanceOfType<Guid>(questionId.Value.Value, "the Id of questionId is not of type Guid");
        }

        [TestMethod]
        public void QuestionIdCreateWithStringNotValidShouldResultOK()
        {
            // Prepare
            string myGuid = "XXXX";

            // Execute
            ErrorOr<Id> questionId = Id.Create(myGuid);

            // Verify
            Assert.IsNotNull(questionId, "questionId is not null");
            Assert.IsTrue(questionId.IsError, "questionId has no error and should have it ");
            Assert.IsInstanceOfType<ErrorOr<Id>>(questionId, "questionId is not of type ErrorOr");
            Assert.IsNull(questionId.Value, "questionId does not register errors");
            Assert.IsNotNull(questionId.Errors, "questionId does not register errors");
            Assert.IsTrue(questionId.Errors.Count > 0, "questionId does not register errors");
        }

        [TestMethod]
        public void QuestionIdCreateWithStringEmptyShouldResultOK()
        {
            // Prepare
            string myGuid = "";

            // Execute
            ErrorOr<Id> questionId = Id.Create(myGuid);

            // Verify
            Assert.IsNotNull(questionId, "questionId is not null");
            Assert.IsTrue(questionId.IsError, "questionId has no error and should have it ");
            Assert.IsInstanceOfType<ErrorOr<Id>>(questionId, "questionId is not of type ErrorOr");
            Assert.IsNull(questionId.Value, "questionId does not register errors");
            Assert.IsNotNull(questionId.Errors, "questionId does not register errors");
            Assert.IsTrue(questionId.Errors.Count > 0, "questionId does not register errors");
        }

    }
}
