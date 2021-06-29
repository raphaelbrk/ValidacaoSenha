using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Validacao.Senha.Domain.Extensions;
using Validacao.Senha.Web;
using Validacao.Senha.Web.ViewModel;

namespace Validacao.Senha.IntegrationTests
{
    /// <summary>
    /// Classe base responsável em guardar os metódos compartilhados dos testes integrados.
    /// </summary>
    /// <seealso cref="Startup" />
    public abstract class BaseTest : WebApplicationFactory<Startup>
    {
        private static HttpClient _httpClient;

        protected HttpClient ObterHttpClient()
        {
            if (_httpClient.NaoEhNulo()) return _httpClient;

            _httpClient = new WebApplicationFactory<Startup>().CreateDefaultClient();
            CriarTokenAuthorization(_httpClient).Wait();

            return _httpClient;
        }

        protected async Task CriarTokenAuthorization(HttpClient httpClient)
        {
            var response = await httpClient.GetAsync("/Token");

            var token = await response.Content.ReadAsStringAsync();

            token = token.Replace("bearer", string.Empty).Trim();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        }

        protected async Task<HttpResponseMessage> Post(object objeto, string endpoint, HttpClient httpClient)
        {
            HttpContent httpContent =
                new StringContent(JsonConvert.SerializeObject(objeto), null, "application/json");

            return await httpClient.PostAsync(endpoint, httpContent);
        }

        protected static async Task<RetornoViewModel> RetornarResponse(HttpResponseMessage response)
        {
            var retornoApi = await response.Content.ReadAsStringAsync();
            var retorno = JsonConvert.DeserializeObject<RetornoViewModel>(retornoApi);
            return retorno;
        }

        protected static void TestarStatusCode(HttpResponseMessage response, HttpStatusCode statusCode)
        {
            Assert.IsTrue(response.StatusCode.Equals(statusCode));
        }
    }
}