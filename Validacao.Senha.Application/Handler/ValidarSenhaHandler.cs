using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Validacao.Senha.Application.Interfaces;
using Validacao.Senha.Application.Query;
using Validacao.Senha.Domain.Constantes;
using Validacao.Senha.Domain.Entities;
using Validacao.Senha.Domain.Enums;
using Validacao.Senha.Domain.Exceptions;
using Validacao.Senha.Domain.Extensions;

namespace Validacao.Senha.Application.Handler
{
    /// <summary>
    /// Classe responsável em receber as validações da senha do projeto da API para Application.
    /// </summary>
    /// <seealso cref="Guid" />
    internal class ValidarSenhaHandler : IRequestHandler<ValidarSenhaQuery, object>
    {
        private readonly INotificacaoContext _notificationContext;

        public ValidarSenhaHandler(
            INotificacaoContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task<object> Handle(ValidarSenhaQuery request, CancellationToken cancellationToken)
        {
            var senha = new SenhaEntity(request.Conteudo);
            if (!senha.Validar()) _notificationContext.Adicionar(senha.ValidacaoResult);
            else _notificationContext.Adicionar(new NotificacaoEntity(CodigoSucessoValidacaoEnum.Sucesso01.ObterDescricao(), MensagensConstantes.SENHA_CORRETO, RetornoEnum.Sucesso));

            return senha.Id.ToString();
        }
    }
}