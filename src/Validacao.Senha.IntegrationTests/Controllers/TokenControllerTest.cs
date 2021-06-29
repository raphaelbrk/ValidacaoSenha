using NUnit.Framework;
using System;
using System.Net;
using System.Threading.Tasks;
using Validacao.Senha.Domain.Extensions;

namespace Validacao.Senha.IntegrationTests.Controllers
{
    /// <summary>
    /// Classe responsável em executar os testes da integração da geração do token.
    /// </summary>
    /// <seealso cref="Validacao.Senha.IntegrationTests.BaseTest" />
    internal class TokenControllerTest : BaseTest
    {
        [Test]
        public async Task Gerar_Token_Sucesso()
        {
            var response = await ObterHttpClient().GetAsync("/Token");
            Assert.IsTrue(response.StatusCode.Equals((HttpStatusCode.OK)));

            var token = await response.Content.ReadAsStringAsync();

            Assert.IsNotEmpty(token);
        }

        [Test]
        public async Task Verficar_Token_Possuir_Bearer()
        {
            var response = await ObterHttpClient().GetAsync("/Token");
            Assert.IsTrue(response.StatusCode.Equals((HttpStatusCode.OK)));

            var token = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(token.Contains("bearer", StringComparison.CurrentCultureIgnoreCase));
        }

        [Test]
        public async Task Verficar_Token_Possuir_Token()
        {
            var response = await ObterHttpClient().GetAsync("/Token");
            Assert.IsTrue(response.StatusCode.Equals((HttpStatusCode.OK)));

            var token = await response.Content.ReadAsStringAsync();

            token = token.Replace("bearer", string.Empty).Trim();

            Assert.IsFalse(token.EhNuloOuExisteEspaco() || string.IsNullOrWhiteSpace(token));
        }
    }
}