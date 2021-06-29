using NUnit.Framework;
using Validacao.Senha.Domain.Exceptions;
using Validacao.Senha.Domain.Helpers;

namespace Validacao.Senha.UnitTests.Helpers
{
    /// <summary>
    /// Classe responsável em executar os testes de descriptografar a senha.
    /// </summary>
    /// <seealso cref="Validacao.Senha.UnitTests.BaseTest" />
    public class DescriptografarHelperTest : BaseTest
    {
        private const string SENHA_COM_ESPACO_CRPTY = "uF0Zo65YbgQ3vZGOVOFLrQKHcf3lq7NLX456nZtdNv0=       ";

        private const string SENHA_SEM_ESPACO_CRPTY = "uF0Zo65YbgQ3vZGOVOFLrQKHcf3lq7NLX456nZtdNv0=";

        [Test]
        public void Descriptografar_Falha_String_Com_Espaco()
        {
            Assert.Throws<EncriptacaoPossuiEspacoException>(() => SENHA_COM_ESPACO_CRPTY.Descriptografar());
        }

        [Test]
        public void Descriptografar_String_Preenchida_Sucess()
        {
            Assert.DoesNotThrow(() => SENHA_SEM_ESPACO_CRPTY.Descriptografar());
        }

        [Test]
        public void Descriptografar_String_Vazia()
        {
            Assert.AreEqual(string.Empty.Descriptografar(), string.Empty);
        }
    }
}