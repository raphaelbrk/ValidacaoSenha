using NUnit.Framework;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Validacao.Senha.Application.Query;
using Validacao.Senha.Domain.Enums;

namespace Validacao.Senha.IntegrationTests.Controllers
{
    /// <summary>
    /// Classe responsável em validar a integração do controller de validação.
    /// </summary>
    /// <seealso cref="Validacao.Senha.IntegrationTests.BaseTest" />
    internal class ValidarControllerTest : BaseTest
    {
        #region "Testes"

        [Test]
        public async Task Validar_Senha_BadRquest()
        {
            var response = await Post(new ValidarSenhaQuery("abc123"), "/Validar", ObterHttpClient());

            TestarStatusCode(response, HttpStatusCode.BadRequest);
            var retorno = await RetornarResponse(response);

            Assert.IsTrue(retorno?.Notificacoes?.Count > 0);
        }

        [Test]
        public async Task Validar_Senha_BadRquest_Eh_Nulo()
        {
            var response = await Post(new ValidarSenhaQuery("abc123"), "/Validar", ObterHttpClient());

            TestarStatusCode(response, HttpStatusCode.BadRequest);
            var retorno = await RetornarResponse(response);

            Assert.IsNotNull(retorno);
            Assert.IsNotNull(retorno.Notificacoes);
        }

        [Test]
        public async Task Validar_Senha_BadRquest_Senha_Com_Espaco()
        {
            var response = await Post(new ValidarSenhaQuery("AbTp9 fok"), "/Validar", ObterHttpClient());

            TestarStatusCode(response, HttpStatusCode.BadRequest);
            var retorno = await RetornarResponse(response);

            Assert.IsTrue(retorno.Notificacoes.Where(x => x.Retorno.Equals(RetornoEnum.Inconsistencia))?.Any());
        }

        [Test]
        public async Task Validar_Senha_BadRquest_Senha_Letra_Repetida()
        {
            var response = await Post(new ValidarSenhaQuery("aa"), "/Validar", ObterHttpClient());

            TestarStatusCode(response, HttpStatusCode.BadRequest);
            var retorno = await RetornarResponse(response);

            Assert.IsTrue(retorno.Notificacoes.Where(x => x.Retorno.Equals(RetornoEnum.Inconsistencia))?.Any());
        }

        [Test]
        public async Task Validar_Senha_BadRquest_Senha_Sem_Caracter_Especial()
        {
            var response = await Post(new ValidarSenhaQuery("AAAbbbCc"), "/Validar", ObterHttpClient());

            TestarStatusCode(response, HttpStatusCode.BadRequest);
            var retorno = await RetornarResponse(response);

            Assert.IsTrue(retorno.Notificacoes.Where(x => x.Retorno.Equals(RetornoEnum.Inconsistencia))?.Any());
        }

        [Test]
        public async Task Validar_Senha_BadRquest_Senha_Sucesso()
        {
            var response = await Post(new ValidarSenhaQuery("AbTp9!fok"), "/Validar", ObterHttpClient());

            TestarStatusCode(response, HttpStatusCode.OK);
            var retorno = await RetornarResponse(response);

            Assert.IsTrue(retorno.Notificacoes.Where(x => x.Retorno.Equals(RetornoEnum.Sucesso))?.Any());
        }

        [Test]
        public async Task Validar_Senha_BadRquest_Senha_Vazio()
        {
            var response = await Post(new ValidarSenhaQuery(""), "/Validar", ObterHttpClient());

            TestarStatusCode(response, HttpStatusCode.BadRequest);
            var retorno = await RetornarResponse(response);

            Assert.IsTrue(retorno.Notificacoes.Where(x => x.Retorno.Equals(RetornoEnum.Inconsistencia))?.Any());
        }

        [Test]
        public async Task Validar_Senha_BadRquest_Menos_Nove_Caracter()
        {
            var response = await Post(new ValidarSenhaQuery("AbTp9!fo"), "/Validar", ObterHttpClient());

            TestarStatusCode(response, HttpStatusCode.BadRequest);
            var retorno = await RetornarResponse(response);

            Assert.IsTrue(retorno.Notificacoes.Where(x => x.Retorno.Equals(RetornoEnum.Inconsistencia))?.Any());
        }

        #endregion "Testes"
    }
}