

using AppCommonServices.Domain.Faq.ValueObjects;

namespace AppCommonServices.Test.Domain.Faq.ValueObjects
{
    [TestClass]
    public class AnswerNameUnitTest
    {
        [TestMethod]
        public void AnswerNameCreateWhenAnswerNameIsValidShouldResultOK()
        {
            // Prepare
            var toCreate = "AnswerName";

            // Execute
            var result = AnswerName.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void AnswerNameCreateWhenAnswerNameMinLengthShouldReturnCommentsObject()
        {
            // Prepare
            var toCreate = new string('p', 2);

            // Execute
            var result = AnswerName.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void AnswerNameCreateWhenAnswerNameMaxLengthShouldReturnCommentsObject()
        {
            // Prepare
            var toCreate = new string('p', 1000);

            // Execute
            var result = AnswerName.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void AnswerNameCreateWhenAnswerNameIsShortShouldResultNull()
        {
            // Prepare            
            var toCreate = "5";

            // Execute
            var result = AnswerName.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void AnswerNameCreateWhenAnswerNameIsTooLongShouldResultNull()
        {
            // Prepare            
            var toCreate = new string('p', 1001);

            // Execute
            var result = AnswerName.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void AnswerNameCreateWhenAnswerNameIsEmptyShouldResultNull()
        {
            // Prepare            
            var toCreate = "";

            // Execute
            var result = AnswerName.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void AnswerNameCreateWhenAnswerNameIsNullShouldResultNull()
        {
            // Prepare            

            // Execute
            var result = AnswerName.Create(null!);

            // Verify
            Assert.IsNull(result, "result is not null");
        }
    }
}