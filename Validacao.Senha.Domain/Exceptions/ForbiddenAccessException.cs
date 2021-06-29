using System;

namespace Validacao.Senha.Domain.Exceptions
{
    /// <summary>
    /// Classe responsável em criar uma excpetion customizada para quando o acesso for negado.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException() : base()
        {
        }
    }
}