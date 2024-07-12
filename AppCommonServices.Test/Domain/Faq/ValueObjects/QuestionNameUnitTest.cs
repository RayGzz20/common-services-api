using AppCommonServices.Domain.Faq.ValueObjects;

namespace AppCommonServices.Test.Domain.Faq.ValueObjects
{
    [TestClass]
    public class QuestionNameUnitTest
    {
        [TestMethod]
        public void QuestionNameCreateWhenQuestionNameIsValidShouldResultOK()
        {
            // Prepare
            var toCreate = "QuestionName";

            // Execute
            var result = QuestionName.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void QuestionNameCreateWhenQuestionNameMinLengthShouldReturnQuestionNameObject()
        {
            // Prepare
            var toCreate = new string('p', 2);

            // Execute
            var result = QuestionName.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void QuestionNameCreateWhenQuestionNameMaxLengthShouldReturnQuestionNameObject()
        {
            // Prepare
            var toCreate = new string('p', 500);

            // Execute
            var result = QuestionName.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void QuestionNameCreateWhenQuestionNameIsShortShouldResultNull()
        {
            // Prepare            
            var toCreate = "5";

            // Execute
            var result = QuestionName.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void QuestionNameCreateWhenQuestionNameIsTooLongShouldResultNull()
        {
            // Prepare            
            var toCreate = new string('p', 501);

            // Execute
            var result = QuestionName.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void QuestionNameCreateWhenQuestionNameIsEmptyShouldResultNull()
        {
            // Prepare            
            var toCreate = "";

            // Execute
            var result = QuestionName.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void QuestionNameCreateWhenQuestionNameIsNullShouldResultNull()
        {
            // Prepare            

            // Execute
            var result = QuestionName.Create(null!);

            // Verify
            Assert.IsNull(result, "result is not null");
        }
    }
}