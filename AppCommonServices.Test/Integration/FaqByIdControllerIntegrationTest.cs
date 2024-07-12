using System.Net;
using System.Net.Http.Json;
using AppCommonServices.WebAPI;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AppCommonServices.Test.Integration
{
    [TestClass]
    public class FaqByIdControllerIntegrationTest
    {
        private HttpClient? _client;
        private static WebApplicationFactory<TestStartup>? _factory;
        private string? _url;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Configurar el cliente HTTP utilizando WebApplicationFactory
            _factory = new WebApplicationFactory<TestStartup>();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // Limpiar recursos después de todas las pruebas
            _factory?.Dispose();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            // Configurar el cliente HTTP
            _client = _factory?.CreateClient();
            _url = "/api/v1/faq";
        }

        [TestMethod]
        public async Task GetById_Returns_NotFound_When_Item_NotExists()
        {
            // Prepare

            // Execute
            var response = await _client!.GetAsync(_url+ "/0A85861B-1BC6-4833-BCA0-4C01FED8D2F/0A85861B");

            // Verify
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task GetById_Returns_BadRequest_When_Id_Invalid()
        {
            // Prepare

            // Execute
            var response = await _client!.GetAsync(_url+"/-1");

            // Verify
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}