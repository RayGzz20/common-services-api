using AppCommonServices.Test.Utilities;
using AppCommonServices.WebAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace AppCommonServices.Test.Integration
{
    [TestClass]
    public class FeedbackControllerIntegrationTest
    {
        private HttpClient _client;
        private static WebApplicationFactory<TestStartup> _factory;
        private string _url;

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
            _factory.Dispose();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            // Configurar el cliente HTTP
            _client = _factory.CreateClient();
            _url = "/api/v1/feedback/";
        }

        [TestMethod]
        public async Task CreateFeedback_WithValidData_ReturnsOkWithCode201()
        {
            // Prepare
            var request = new { UserId = new Guid("413E7760-427C-4B7D-AE9E-A76A5EC7DF88").ToString(), Comments = "Muy buen upgrade de la app. Saludos" };
            string jsonValue = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(jsonValue, Encoding.UTF8, "application/json");

            // Execute
            var response = await _client!.PostAsync(_url, content);

            string json = "";
            Guid modelo = new Guid();

            if (response.IsSuccessStatusCode && response.StatusCode==HttpStatusCode.Created)
            {
                try
                {
                    // Obtiene el contenido de la respuesta como un objeto JSON
                    json = await response.Content.ReadAsStringAsync();

                    // Deserializa el JSON en un objeto de tu clase modelo
                    modelo = JsonConvert.DeserializeObject<Guid>(json);
                }
                catch
                {
                    json = "";
                    modelo = new Guid();
                }                
            }

            // Verify
            Assert.IsTrue(response.IsSuccessStatusCode, "The response is not success");
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode, "The response is not status Created");
            Assert.IsFalse(json.IsNullOrEmpty(), "The response is empty");
            Assert.IsNotNull(modelo, "There isn't an key");
            Assert.IsInstanceOfType<Guid>(modelo, "There isn't an key");
            Assert.AreNotEqual(modelo.ToString(), new Guid().ToString(), "There isn't an key");
        }

        [TestMethod]
        public async Task CreateFeedback_WithEmptyData_ReturnsErrorWithCode400AnCommandError()
        {
            // Prepare
            StringContent content = new StringContent("", Encoding.UTF8, "application/json");

            // Execute
            var response = await _client!.PostAsync(_url, content);

            var json = await response.Content.ReadAsStringAsync();

            // Deserializa el JSON en un objeto de tu clase modelo AppCommonServicesProblemDetailsFactory
            var modelo = JsonConvert.DeserializeObject<ProblemDetailsForTest>(json);          

            // Verify
            Assert.IsFalse(response.IsSuccessStatusCode, "The response is not an error");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode, "The response status is not an error");
            Assert.IsFalse(json.IsNullOrEmpty(), "The response is empty");
            Assert.IsNotNull(modelo, "There isn't an error");
            Assert.IsInstanceOfType<ProblemDetails>(modelo, "There isn't an ProblemDetails type");
            Assert.IsTrue(modelo.Status == 400, "There isn't an error");
            Assert.IsTrue(modelo.Title == "One or more validation errors occurred.", "There isn't an error");
            Assert.IsNotNull(modelo.Extensions, "There isn't errors collection");
            Assert.IsTrue(modelo.Extensions.Count > 0, "There isn't errors collection");
            Assert.IsTrue(modelo.Extensions.ContainsKey("command"), "There isn't a command error");
        }

        [TestMethod]
        public async Task CreateFeedback_WithEmptyData_ReturnsErrorWithCode404AndUserIdNotValid()
        {
            // Prepare
            var request = new { UserId = "", Comments = "Muy buen upgrade de la app. Saludos" };
            string jsonValue = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(jsonValue, Encoding.UTF8, "application/json");

            // Execute
            var response = await _client!.PostAsync(_url, content);

            var json = await response.Content.ReadAsStringAsync();

            // Deserializa el JSON en un objeto de tu clase modelo AppCommonServicesProblemDetailsFactory
            var modelo = JsonConvert.DeserializeObject<ProblemDetailsForTest>(json);

            // Verify
            Assert.IsFalse(response.IsSuccessStatusCode, "The response is not an error");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode, "The response status is not an error");
            Assert.IsFalse(json.IsNullOrEmpty(), "The response is empty");
            Assert.IsNotNull(modelo, "There isn't an error");
            Assert.IsInstanceOfType<ProblemDetails>(modelo, "There isn't an ProblemDetails type");
            Assert.IsTrue(modelo.Status == 400, "There isn't an error");
            Assert.IsTrue(modelo.Title == "One or more validation errors occurred.", "There isn't an error");
            Assert.IsNotNull(modelo.Extensions, "There isn't errors collection");
            Assert.IsTrue(modelo.Extensions.Count > 0, "There isn't errors collection");
            Assert.IsTrue(modelo.Extensions.ContainsKey("UserId"), "There isn't a Comments error");
        }

        [TestMethod]
        public async Task CreateFeedback_WithEmptyData_ReturnsErrorWithCode404AndCommentsNotValid()
        {
            // Prepare
            var request = new { UserId = new Guid("413E7760-427C-4B7D-AE9E-A76A5EC7DF88").ToString(), Comments = "" };
            string jsonValue = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(jsonValue, Encoding.UTF8, "application/json");

            // Execute
            var response = await _client!.PostAsync(_url, content);

            var json = await response.Content.ReadAsStringAsync();

            // Deserializa el JSON en un objeto de tu clase modelo AppCommonServicesProblemDetailsFactory
            var modelo = JsonConvert.DeserializeObject<ProblemDetailsForTest>(json);

            // Verify
            Assert.IsFalse(response.IsSuccessStatusCode, "The response is not an error");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode, "The response status is not an error");
            Assert.IsFalse(json.IsNullOrEmpty(), "The response is empty");
            Assert.IsNotNull(modelo, "There isn't an error");
            Assert.IsInstanceOfType<ProblemDetails>(modelo, "There isn't an ProblemDetails type");
            Assert.IsTrue(modelo.Status == 400, "There isn't an error");
            Assert.IsTrue(modelo.Title == "One or more validation errors occurred.", "There isn't an error");
            Assert.IsNotNull(modelo.Extensions, "There isn't errors collection");
            Assert.IsTrue(modelo.Extensions.Count > 0, "There isn't errors collection");
            Assert.IsTrue(modelo.Extensions.ContainsKey("Comments"), "There isn't a Comments error");
        }        
    }
}
