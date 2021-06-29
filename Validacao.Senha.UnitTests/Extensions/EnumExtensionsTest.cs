using NUnit.Framework;
using System;
using Validacao.Senha.Domain.Enums;
using Validacao.Senha.Domain.Exceptions;
using Validacao.Senha.Domain.Extensions;

namespace Validacao.Senha.UnitTests.Extensions
{
    public class EnumExtensionsTest : BaseTest
    {
        [Test]
        public void Enum_Description_Sucess()
        {
            Assert.DoesNotThrow(() => AcaoEncryptionEnum.Encrypt.ObterDescricao());
        }

        [Test]
        public void Enum_Null_Description_Fail()
        {
            Enum @enum = null;

            Assert.Throws<EnumDescricaoNuloReferenceException>(() => @enum.ObterDescricao());
        }
    }
}