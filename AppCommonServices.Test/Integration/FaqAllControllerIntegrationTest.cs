using System.Net;
using System.Text;
using AppCommonServices.Domain.Faq.ValueObjects;
using AppCommonServices.WebAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Playwright;
using Newtonsoft.Json;

namespace AppCommonServices.Test.Integration
{
    [TestClass]
    public class FaqAllControllerIntegrationTest
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
        public async Task Should_Return_Status_Code_200()
        {
            // Prepare

            // Execute
            var response = await _client!.GetAsync(_url);
            
            // Verify
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Should_Return_ContentTypeJson_Not_Null()
        {    
            // Prepare

            // Execute
            var response = await _client!.GetAsync(_url);
            var json = await response.Content.ReadAsStringAsync();

            // Verify
            Assert.IsFalse(json.IsNullOrEmpty(), "The response is empty");
        }

        [TestMethod]
        public async Task Should_Return_BadRequest_For_Invalid_Id()
        {
            // Prepare
            
            // Execute
            var response = await _client!.GetAsync("/api/v1/faq/7");

            // Verify
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}