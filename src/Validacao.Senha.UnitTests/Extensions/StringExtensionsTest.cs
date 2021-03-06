using NUnit.Framework;
using Validacao.Senha.Domain.Extensions;

namespace Validacao.Senha.UnitTests.Extensions
{
    /// <summary>
    /// Classe responsável em executar os testes de classe de extensão de strings.
    /// </summary>
    /// <seealso cref="Validacao.Senha.UnitTests.BaseTest" />
    internal class StringExtensionsTest : BaseTest
    {
        [Test]
        public void Encrypt_String_Preenchida_Sem_Espaco_Sucess()
        {
            Assert.IsFalse("Valor".EhNuloOuExisteEspaco());
        }

        [Test]
        public void Encrypt_String_Vazia()
        {
            Assert.IsFalse(string.Empty.EhNuloOuExisteEspaco());
        }

        [Test]
        public void Encrypt_Fail_String_Nula()
        {
            string valor = null;

            Assert.IsFalse(valor.EhNuloOuExisteEspaco());
        }
    }
}