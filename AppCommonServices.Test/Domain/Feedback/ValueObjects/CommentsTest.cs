using AppCommonServices.Domain.Feedback.ValueObjects;

namespace AppCommonServices.Test.Domain.Feedback.ValueObjects
{
    [TestClass]
    public class CommentsTest
    {
        [TestMethod]
        public void CommentsCreateWhenCommentsIsValidShouldResultOK()
        {
            // Prepare
            var toCreate = "Comments";

            // Execute
            var result = Comments.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void CommentsCreateWhenCommentsMinLengthShouldReturnCommentsObject()
        {
            // Prepare
            var toCreate = new string('p', 2);

            // Execute
            var result = Comments.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void CommentsCreateWhenCommentsMaxLengthShouldReturnCommentsObject()
        {
            // Prepare
            var toCreate = new string('p', 850);

            // Execute
            var result = Comments.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void CommentsCreateWhenCommentsIsShortShouldResultNull()
        {
            // Prepare            
            var toCreate = "5";

            // Execute
            var result = Comments.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void CommentsCreateWhenCommentsIsTooLongShouldResultNull()
        {
            // Prepare            
            var toCreate = new string('p', 851);

            // Execute
            var result = Comments.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void CommentsCreateWhenCommentsIsEmptyShouldResultNull()
        {
            // Prepare            
            var toCreate = "";

            // Execute
            var result = Comments.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void CommentsCreateWhenCommentsIsNullShouldResultNull()
        {
            // Prepare            

            // Execute
            var result = Comments.Create(null!);

            // Verify
            Assert.IsNull(result, "result is not null");
        }
    }
}
