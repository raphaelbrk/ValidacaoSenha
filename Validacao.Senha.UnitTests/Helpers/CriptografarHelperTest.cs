using NUnit.Framework;
using Validacao.Senha.Domain.Exceptions;
using Validacao.Senha.Domain.Helpers;

namespace Validacao.Senha.UnitTests.Helpers
{
    /// <summary>
    /// Classe responsável em executar os testes de criptografar a senha.
    /// </summary>
    /// <seealso cref="Validacao.Senha.UnitTests.BaseTest" />
    internal class CriptografarHelperTest : BaseTest
    {
        private const string SENHA_COM_ESPACO_DECPRTY = "teste123  123";

        private const string SENHA_CRPTY = "uF0Zo65YbgQ3vZGOVOFLrQKHcf3lq7NLX456nZtdNv0=";
        private const string SENHA_SEM_ESPACO_DECPRTY = "teste123";

        [Test]
        public void Criptografar_Fail_String_Com_Espaco()
        {
            Assert.Throws<EncriptacaoPossuiEspacoException>(() => SENHA_COM_ESPACO_DECPRTY.Criptografar());
        }

        [Test]
        public void Criptografar_String_Preenchida_Sucess()
        {
            Assert.DoesNotThrow(() => SENHA_SEM_ESPACO_DECPRTY.Criptografar());
        }

        [Test]
        public void Criptografar_String_Vazia()
        {
            Assert.AreEqual(string.Empty.Criptografar(), string.Empty);
        }
    }
}