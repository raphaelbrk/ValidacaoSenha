using System;
using Validacao.Senha.Domain.Enums;
using Validacao.Senha.Domain.Extensions;

namespace Validacao.Senha.Domain.Exceptions
{
    /// <summary>
    /// Classe responsável em criar uma excpetion customizada para quando a senha possuir espaço.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class EncriptacaoPossuiEspacoException : Exception
    {
        public EncriptacaoPossuiEspacoException(AcaoEncryptionEnum acao)
            : base($"Ação \"{acao.ObterDescricao()}\" não pode possuir espaço.")
        {
        }
    }
}