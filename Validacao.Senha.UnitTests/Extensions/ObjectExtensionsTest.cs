using NUnit.Framework;
using Validacao.Senha.Domain.Extensions;

namespace Validacao.Senha.UnitTests.Extensions
{
    /// <summary>
    /// Classe responsável em executar os testes de classe de extensão de objetos.
    /// </summary>
    /// <seealso cref="Validacao.Senha.UnitTests.BaseTest" />
    public class ObjectExtensionsTest : BaseTest
    {
        [Test]
        public void IsNull_Sucess()
        {
            object @object = null;

            Assert.IsTrue(@object.EhNulo());
        }

        [Test]
        public void IsNull_Fail()
        {
            object @object = new();

            Assert.IsFalse(@object.EhNulo());
        }

        [Test]
        public void IsNotNull_Sucess()
        {
            object @object = new();

            Assert.IsTrue(@object.NaoEhNulo());
        }

        [Test]
        public void IsNotNull_Fail()
        {
            object @object = null;

            Assert.IsFalse(@object.NaoEhNulo());
        }

        [Test]
        public void ToStringContent_Converter_Sucess()
        {
            object @object = new { Teste = "teste" };

            Assert.DoesNotThrow(() => @object.ToStringContent());
        }
    }
}