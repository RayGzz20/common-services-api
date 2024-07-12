using AppCommonServices.Domain.Faq.ValueObjects;

namespace AppCommonServices.Test.Domain.Faq.ValueObjects
{
    [TestClass]
    public class UrlImageUnitTest
    {
        [TestMethod]
        public void UrlImageCreateWhenUrlImageIsValidShouldResultOK()
        {
            // Prepare
            var toCreate = "UrlImage";

            // Execute
            var result = UrlImage.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void UrlImageCreateWhenUrlImageMinLengthResultOK()
        {
            // Prepare
            var toCreate = new string('p', 2);

            // Execute
            var result = UrlImage.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void UrlImageCreateWhenUrlImageMaxLengthResultOK()
        {
            // Prepare
            var toCreate = new string('p', 255);

            // Execute
            var result = UrlImage.Create(toCreate);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.AreEqual(toCreate, result!.Value, "result is not equal to the provided one");
        }

        [TestMethod]
        public void UrlImageCreateWhenUrlImageIsShortShouldResultNull()
        {
            // Prepare            
            var toCreate = "5";

            // Execute
            var result = UrlImage.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void UrlImageCreateWhenUrlImageIsTooLongShouldResultNull()
        {
            // Prepare            
            var toCreate = new string('p', 256);

            // Execute
            var result = UrlImage.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void UrlImageCreateWhenUrlImageIsEmptyShouldResultNull()
        {
            // Prepare            
            var toCreate = "";

            // Execute
            var result = UrlImage.Create(toCreate);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void UrlImageCreateWhenUrlImageIsNullShouldResultNull()
        {
            // Prepare            

            // Execute
            var result = UrlImage.Create(null!);

            // Verify
            Assert.IsNull(result, "result is not null");
        }
    }
}

