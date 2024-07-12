using AppCommonServices.Domain.Common.ValueObjects;
using AppCommonServices.Domain.Faq.ValueObjects;
using DomainFaq = AppCommonServices.Domain.Faq.Entities;
using ErrorOr;

namespace AppCommonServices.Test.Domain.Faq.Entities
{
    [TestClass]
    public class FaqTest
    {
        [TestMethod]
        public void FaqCreateWhenFaqIsValidShouldResultOK()
        {
            // Prepare
            FaqName? name = FaqName.Create("FaqTest");
            FaqPosition? position = FaqPosition.Create(1);
            UrlImage? urlImage = UrlImage.Create("UrlImage");

            // Execute
            DomainFaq.Faq? result = DomainFaq.Faq.Create(name!, urlImage!, position!, true);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.IsInstanceOfType<DomainFaq.Faq>(result, "result is not of type Faq");
            Assert.IsNotNull(result.Id, "result does not have an Id");
            Assert.IsInstanceOfType<Id>(result.Id, "the Id of result is not of type FaqId");
            Assert.IsTrue(result.Id.Value.ToString().Length > 0, "result does not have an Id with value");
            Assert.IsInstanceOfType<Guid>(result.Id.Value, "the Id of result is not of type Guid");
        }

        [TestMethod]
        public void FaqCreateWhenFaqNameIsNotValidShouldResultError()
        {
            // Prepare            
            FaqPosition? position = FaqPosition.Create(1);
            UrlImage? urlImage = UrlImage.Create("UrlImage");

            // Execute
            DomainFaq.Faq? result = DomainFaq.Faq.Create(null!, urlImage!, position!, true);

            // Verify
            Assert.IsNull(result, "result is null");
        }

        [TestMethod]
        public void FaqCreateWhenUrlImageIsNotValidShouldResultError()
        {
            // Prepare            
            FaqName? name = FaqName.Create("FaqTest");
            FaqPosition? position = FaqPosition.Create(1);

            // Execute
            DomainFaq.Faq? result = DomainFaq.Faq.Create(name!, null!, position!, true);

            // Verify
            Assert.IsNull(result, "result is null");
        }

        [TestMethod]
        public void FaqCreateWhenFaqPositionIsNotValidShouldResultError()
        {
            // Prepare            
            FaqName? name = FaqName.Create("FaqTest");
            UrlImage? urlImage = UrlImage.Create("UrlImage");

            // Execute
            DomainFaq.Faq? result = DomainFaq.Faq.Create(name!, urlImage!, null!, true);

            // Verify
            Assert.IsNull(result, "result is null");
        }
    }
}
