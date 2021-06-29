using NUnit.Framework;
using Validacao.Senha.Domain.Extensions;
using Validacao.Senha.Domain.Helpers;

namespace Validacao.Senha.UnitTests.Extensions
{
    public class StringExtensionsTest : BaseTest
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