using AutoFixture.AutoMoq;
using AutoFixture;

namespace AppCommonServices.Test.Utilities
{
    public class UnitTestBase
    {
        protected readonly Fixture _fixture;

        public UnitTestBase()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
        }
    }
}
