using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Validacao.Senha.Application.Command;
using Validacao.Senha.Application.Interfaces;
using Validacao.Senha.Domain.Constantes;
using Validacao.Senha.Domain.Entities;
using Validacao.Senha.Domain.Enums;
using Validacao.Senha.Domain.Extensions;
using Validacao.Senha.Infrastructure.Interfaces;

namespace Validacao.Senha.Application.Handler
{
    /// <summary>
    /// Classe responsável em receber as informações do comando de gravação da API para o projeto Application.
    /// </summary>
    /// <seealso cref="Guid" />
    internal class GravarSenhaHandler : IRequestHandler<GravarSenhaCommand, object>
    {
        private readonly INotificacaoContext _notificationContext;
        private readonly ISenhaRepository _senhaRepository;

        public GravarSenhaHandler(
            INotificacaoContext notificationContext,
            ISenhaRepository senhaRepository)
        {
            _notificationContext = notificationContext;
            _senhaRepository = senhaRepository;
        }

        public async Task<object> Handle(GravarSenhaCommand request, CancellationToken cancellationToken)
        {
            var senha = new SenhaEntity(request.Conteudo.ToString());
            if (!senha.Validar()) _notificationContext.Adicionar(senha.ValidacaoResult);
            else
            {
                _senhaRepository.Adicionar(senha);
                _notificationContext.Adicionar(new NotificacaoEntity(CodigoSucessoValidacaoEnum.Sucesso01.ObterDescricao(), MensagensConstantes.SENHA_CORRETO, RetornoEnum.Sucesso));
            }

            return senha.Id.ToString();
        }
    }
}