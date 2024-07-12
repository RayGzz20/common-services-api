using AppCommonServices.Domain.Feedback.ValueObjects;

namespace AppCommonServices.Test.Domain.Feedback.ValueObjects
{
    [TestClass]
    public class UserIdTest
    {
        [TestMethod]
        public void UserIdCreateWhenUserIdIsValidShouldResultOK()
        {
            // Prepare
            var toCreate = "UserId";

            // Execute
            var result = UserId.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void UserIdCreateWhenUserIdMinLengthShouldReturnUserIdObject()
        {
            // Prepare
            var toCreate = new string('p', 2);

            // Execute
            var result = UserId.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void UserIdCreateWhenUserIdMaxLengthShouldReturnUserIdObject()
        {
            // Prepare
            var toCreate = new string('p', 50);

            // Execute
            var result = UserId.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void UserIdCreateWhenUserIdIsShortShouldResultNull()
        {
            // Prepare            
            var toCreate = "5";

            // Execute
            var result = UserId.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void UserIdCreateWhenUserIdIsTooLongShouldResultNull()
        {
            // Prepare            
            var toCreate = new string('p', 51);

            // Execute
            var result = UserId.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void UserIdCreateWhenUserIdIsEmptyShouldResultNull()
        {
            // Prepare            
            var toCreate = "";

            // Execute
            var result = UserId.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void UserIdCreateWhenUserIdIsNullShouldResultNull()
        {
            // Prepare            

            // Execute
            var result = UserId.Create(null!);

            // Verify
            Assert.IsNull(result, "result is not null");
        }
    }
}
