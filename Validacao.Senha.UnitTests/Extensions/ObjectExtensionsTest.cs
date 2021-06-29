using NUnit.Framework;
using Validacao.Senha.Domain.Extensions;

namespace Validacao.Senha.UnitTests.Extensions
{
    /// <summary>
    /// Classe responsável em executar os testes de classe de extensão de objetos.
    /// </summary>
    /// <seealso cref="Validacao.Senha.UnitTests.BaseTest" />
    internal class ObjectExtensionsTest : BaseTest
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
        public void IsNotNull_Sucesso()
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
        public void CriarLista_Converter_Sucesso()
        {
            object @object = new { Teste = "teste" };

            Assert.DoesNotThrow(() => @object.CriaLista());
        }

        [Test]
        public void CriarLista_Converter_Nulo()
        {
            object @object = null;

            Assert.DoesNotThrow(() => @object.CriaLista());
        }


        [Test]
        public void ToStringContent_Converter_Sucess()
        {
            object @object = new { Teste = "teste" };

            Assert.DoesNotThrow(() => @object.ToStringContent());
        }
    }
}