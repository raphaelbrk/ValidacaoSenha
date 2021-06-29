using NUnit.Framework;
using System.Linq;
using Validacao.Senha.Domain.Constantes;
using Validacao.Senha.Domain.Entities;

namespace Validacao.Senha.UnitTests.Validations
{
    /// <summary>
    /// Classe responsável em executar os testes unitários das validações.
    /// </summary>
    /// <seealso cref="Validacao.Senha.UnitTests.BaseTest" />
    internal class SenhaValidatorTest : BaseTest
    {
        [Test]
        public void Validar_Senha_Pelo_Menos_Um_Caracter_Especial_Falha()
        {
            var senha = CriarSenha("aBaq23C");

            _ = senha.Validar();

            Assert.IsFalse(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_PELO_MENOS_UM_CARACTER_ESPECIAL)));
        }

        [Test]
        public void Validar_Senha_Pelo_Menos_Um_Caracter_Especial_Sucesso()
        {
            var senha = CriarSenha("aBaq23C!+=");

            _ = senha.Validar();

            Assert.IsTrue(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_PELO_MENOS_UM_CARACTER_ESPECIAL)));
        }

        [Test]
        public void Validar_Senha_Pelo_Menos_Um_Digito_Sucesso()
        {
            var senha = CriarSenha("ab1");

            _ = senha.Validar();

            Assert.IsTrue(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_PELO_MENOS_UM_DIGITO_NUMERICO)));
        }

        [Test]
        public void Validar_Senha_Pelo_Menos_Uma_Letra_Maiscula_Falha()
        {
            var senha = CriarSenha("ab45");

            _ = senha.Validar();

            Assert.IsFalse(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_PELO_MENOS_UMA_LETRA_MAIUSCULA)));
        }

        [Test]
        public void Validar_Senha_Pelo_Menos_Uma_Letra_Maiscula_Sucesso()
        {
            var senha = CriarSenha("aBaq23C");

            _ = senha.Validar();

            Assert.IsTrue(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_PELO_MENOS_UMA_LETRA_MAIUSCULA)));
        }

        [Test]
        public void Validar_Senha_Pelo_Menos_Uma_Letra_Minuscula_Falha()
        {
            var senha = CriarSenha("ABC45");

            _ = senha.Validar();

            Assert.IsFalse(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_PELO_MENOS_UMA_LETRA_MINUSCULA)));
        }

        [Test]
        public void Validar_Senha_Pelo_Menos_Uma_Letra_Minuscula_Sucesso()
        {
            var senha = CriarSenha("aBaq23C");

            _ = senha.Validar();

            Assert.IsTrue(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_PELO_MENOS_UMA_LETRA_MINUSCULA)));
        }

        [Test]
        public void Validar_Senha_Sem_Um_Digito_Falha()
        {
            var senha = CriarSenha("ab");

            _ = senha.Validar();

            Assert.IsFalse(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_PELO_MENOS_UM_DIGITO_NUMERICO)));
        }

        [Test]
        public void Validar_Senha_Valor_Nao_Preenchido_Falha()
        {
            var senha = CriarSenha("");

            _ = senha.Validar();

            Assert.IsFalse(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_NAO_INFORMADA)));
        }

        [Test]
        public void Validar_Senha_Valor_Preenchido_Sucesso()
        {
            var senha = CriarSenha("ab1");

            _ = senha.Validar();

            Assert.IsTrue(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_NAO_INFORMADA)));
        }

        [Test]
        public void Validar_Senha_Valor_Caracter_Repetido_Falha()
        {
            var senha = CriarSenha("aabb32");

            _ = senha.Validar();

            Assert.IsFalse(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_COM_CARACTER_REPETIDO)));
        }

        [Test]
        public void Validar_Senha_Valor_Caracter_Repetido_Sucesso()
        {
            var senha = CriarSenha("abc123");

            _ = senha.Validar();

            Assert.IsTrue(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_COM_ESPACO)));
        }

        [Test]
        public void Validar_Senha_Valor_Com_Espaco_Falha()
        {
            var senha = CriarSenha("aabb32   ");

            _ = senha.Validar();

            Assert.IsFalse(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_COM_ESPACO)));
        }

        [Test]
        public void Validar_Senha_Valor_Com_Espaco_Sucesso()
        {
            var senha = CriarSenha("abc123");

            _ = senha.Validar();

            Assert.IsTrue(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_COM_ESPACO)));
        }

        [Test]
        public void Validar_Senha_Pelo_Menos_Nove_Ou_Mais_Caracteres_Sucesso()
        {
            var senha = CriarSenha("AbTp9!fok");

            _ = senha.Validar();

            Assert.IsTrue(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_COM_MENOS_NOVE_CARACTERES)));
        }

        [Test]
        public void Validar_Senha_Pelo_Menos_Nove_Ou_Mais_Caracteres_Falha()
        {
            var senha = CriarSenha("AbTp9!fo");

            _ = senha.Validar();

            Assert.IsFalse(!senha.ValidacaoResult.Errors.Any(x => x.ErrorMessage.Equals(MensagensConstantes.SENHA_COM_MENOS_NOVE_CARACTERES)));
        }

        private SenhaEntity CriarSenha(string senha)
        {
            return new SenhaEntity(senha);
        }
    }
}