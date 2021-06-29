using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Validacao.Senha.Domain.Extensions;
using Validacao.Senha.Web;

namespace Validacao.Senha.IntegrationTests
{
    /// <summary>
    /// Classe base responsável em guardar os metódos compartilhados dos testes integrados.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory{Validacao.Senha.Web.Startup}" />
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
    }
}