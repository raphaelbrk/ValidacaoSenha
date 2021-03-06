using MediatR;
using System;

namespace Validacao.Senha.Application.Base
{
    /// <summary>
    /// Classe responsável por ser a classe base dos comandos e query do MediatR.
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.string}" />
    public class BaseSenhaQueryCommand<TResponse> : IRequest<TResponse>
    {
        public string Conteudo { get; }
        public Guid Id { get; }

        public BaseSenhaQueryCommand(string conteudo)
        {
            Conteudo = conteudo;
            Id = Guid.NewGuid();
        }
    }
}