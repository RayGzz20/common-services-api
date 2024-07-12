

using AppCommonServices.Domain.Faq.ValueObjects;

namespace AppCommonServices.Test.Domain.Faq.ValueObjects
{
    [TestClass]
    public class PositionUnitTest
    {
        [TestMethod]
        public void PositionCreateWhenPositionIsValidShouldResultOK()
        {
            // Prepare
            int toCreate = 1;

            // Execute
            var result = Position.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.IsTrue(result.Value == toCreate, "result is not equal to the one provided for its creation");
        }

        [TestMethod]
        public void PositionCreateWhenPositionMaxValueShouldResultOK()
        {
            // Prepare
            int maxValidValue = int.MaxValue;

            // Execute
            var result = Position.Create(maxValidValue);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(maxValidValue, result.Value, "result value is not correct");
        }

        [TestMethod]
        public void PositionCreateWhenInvalidPositionShouldResultNull()
        {
            // Prepare
            int toCreate = 0;

            // Execute
            var result = Position.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }        

        [TestMethod]
        public void PositionCreateWhenNegativePositionReturnsNull()
        {
            // Prepare
            int negative = -1;

            // Execute
            var result = Position.Create(negative);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void PositionCreateWhenMultiplePositionsReturnDifferentInstances()
        {
            // Prepare
            int value = 1;

            // Execute
            var result1 = Position.Create(value);
            var result2 = Position.Create(value);

            // Verify
            Assert.IsNotNull(result1, "result1 is null");
            Assert.IsNotNull(result2, "result2 is null");
            Assert.AreNotSame(result1, result2, "both instances are the same");
        }
    }
}