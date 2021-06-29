using System;

namespace Validacao.Senha.Domain.Exceptions
{
    /// <summary>
    /// Classe responsável em criar uma excpetion customizada para quando a entidade não for encontrada.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base()
        {
        }

        public NotFoundException(string mensagem)
            : base(mensagem)
        {
        }

        public NotFoundException(string mensagem, Exception innerException)
            : base(mensagem, innerException)
        {
        }

        public NotFoundException(string nome, object chave)
            : base($"Entidade \"{nome}\" ({chave}) não encontrada.")
        {
        }
    }
}