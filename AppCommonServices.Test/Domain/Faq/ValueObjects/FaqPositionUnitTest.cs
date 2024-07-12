

using AppCommonServices.Domain.Faq.ValueObjects;

namespace AppCommonServices.Test.Domain.Faq.ValueObjects
{
    [TestClass]
    public class FaqPositionUnitTest
    {
        [TestMethod]
        public void FaqPositionCreateWhenFaqPositionIsValidShouldResultOK()
        {
            // Prepare
            int toCreate = 1;

            // Execute
            var result = FaqPosition.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.IsTrue(result.Value == toCreate, "result is not equal to the one provided for its creation");
        }

        [TestMethod]
        public void FaqPositionCreateWhenFaqPositionMaxValueShouldResultOK()
        {
            // Prepare
            int maxValidValue = int.MaxValue;

            // Execute
            var result = FaqPosition.Create(maxValidValue);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(maxValidValue, result.Value, "result value is not correct");
        }

        [TestMethod]
        public void FaqPositionCreateWhenInvalidFaqPositionShouldResultNull()
        {
            // Prepare
            int toCreate = 0;

            // Execute
            var result = FaqPosition.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }        

        [TestMethod]
        public void FaqPositionCreateWhenNegativeFaqPositionReturnsNull()
        {
            // Prepare
            int negative = -1;

            // Execute
            var result = FaqPosition.Create(negative);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void FaqPositionCreateWhenMultipleFaqPositionsReturnDifferentInstances()
        {
            // Prepare
            int value = 1;

            // Execute
            var result1 = FaqPosition.Create(value);
            var result2 = FaqPosition.Create(value);

            // Verify
            Assert.IsNotNull(result1, "result1 is null");
            Assert.IsNotNull(result2, "result2 is null");
            Assert.AreNotSame(result1, result2, "both instances are the same");
        }

        [TestMethod]
        public void FaqPositionCreateWhenPositionIsValidShouldResultOK()
        {
            // Prepare
            int positionToCreate = 1;

            // Execute
            FaqPosition? position = FaqPosition.Create(positionToCreate);

            // Verify
            Assert.IsNotNull(position, "FaqPosition is null");
            Assert.IsTrue(position.Value == positionToCreate, "created position is not equal to the one provided for its creation");
        }

        [TestMethod]
        public void FaqPositionCreateWhenPositionIsNotValidShouldResultNull()
        {
            // Prepare
            int positionToCreate = 0;

            // Execute
            FaqPosition? position = FaqPosition.Create(positionToCreate);

            // Verify
            Assert.IsNull(position, "FaqPosition not is null");
        }
    }
}