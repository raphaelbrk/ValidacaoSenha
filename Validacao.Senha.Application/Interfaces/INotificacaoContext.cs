using FluentValidation.Results;
using System.Collections.Generic;
using Validacao.Senha.Domain.Entities;
using Validacao.Senha.Domain.Enums;

namespace Validacao.Senha.Application.Interfaces
{
    /// <summary>
    /// Interface responsável para adicionar as notificações das validações do FluentValidation que será retornado para o usuário.
    /// </summary>
    public interface INotificacaoContext
    {
        public bool EhNotificacoesComErro { get; }

        public bool EhNotificacaoComSucesso { get; }
        public IReadOnlyCollection<NotificacaoEntity> Notificacoes { get; }

        void Adicionar(string key, string message, RetornoEnum retorno);

        void Adicionar(NotificacaoEntity notificacao);

        void Adicionar(IReadOnlyCollection<NotificacaoEntity> notifications);

        void Adicionar(IList<NotificacaoEntity> notifications);

        void Adicionar(ICollection<NotificacaoEntity> notifications);

        void Adicionar(ValidationResult validationResult);
    }
}