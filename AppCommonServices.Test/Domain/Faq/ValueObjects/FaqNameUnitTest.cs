using AppCommonServices.Domain.Faq.ValueObjects;

namespace AppCommonServices.Test.Domain.Faq.ValueObjects
{
    [TestClass]
    public class FaqNameUnitTest
    {
        [TestMethod]
        public void NameCreateWhenFaqNameIsValidShouldResultOK()
        {
            // Prepare
            var toCreate = "FaqName";

            // Execute
            var result = FaqName.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void FaqNameCreateWhenNameMinLengthShouldResultOK()
        {
            // Prepare
            var toCreate = new string('p', 2);

            // Execute
            var result = FaqName.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void FaqNameCreateWhenNameMaxLengthShouldResultOK()
        {
            // Prepare
            var toCreate = new string('p', 50);

            // Execute
            var result = FaqName.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void FaqNameCreateWhenNameIsShortShouldResultNull()
        {
            // Prepare            
            var toCreate = "5";

            // Execute
            var result = FaqName.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void FaqNameCreateWhenNameIsTooLongShouldResultNull()
        {
            // Prepare            
            var toCreate = new string('p', 51);

            // Execute
            var result = FaqName.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void FaqNameCreateWhenNameIsEmptyShouldResultNull()
        {
            // Prepare            
            var toCreate = "";

            // Execute
            var result = FaqName.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void FaqNameCreateWhenNameIsNullShouldResultNull()
        {
            // Prepare            

            // Execute
            var result = FaqName.Create(null!);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void FaqNameCreateWhenNameIsValidShouldResultOK()
        {
            // Prepare
            var nameToCreate = "FaqNameTest";

            // Execute
            FaqName? name = FaqName.Create(nameToCreate);

            // Verify
            Assert.IsNotNull(name, "FaqName is null");
            Assert.IsTrue(name.Value == nameToCreate, "name created is not the same as the one provided for its creation");
        }
    }
}