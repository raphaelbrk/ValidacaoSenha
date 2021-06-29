using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Validacao.Senha.Application.Interfaces;
using Validacao.Senha.Domain.Entities;
using Validacao.Senha.Domain.Enums;

namespace Validacao.Senha.Application.Context
{
    /// <summary>
    /// Classe responsável por guardar as informações das validações da aplicação.
    /// </summary>
    /// <seealso cref="Validacao.Senha.Application.Interfaces.INotificacaoContext" />
    public class NotificacaoContext : INotificacaoContext
    {
        private readonly List<NotificacaoEntity> _notificacoes;

        public NotificacaoContext()
        {
            _notificacoes = new List<NotificacaoEntity>();
        }

        public bool EhNotificacoesComErro => _notificacoes.Any(x => x.Retorno.Equals(RetornoEnum.Inconsistencia));
        public bool EhNotificacaoComSucesso => _notificacoes.Any(x => x.Retorno.Equals(RetornoEnum.Sucesso));

        public IReadOnlyCollection<NotificacaoEntity> Notificacoes => _notificacoes;

        public void Adicionar(string key, string message, RetornoEnum retorno)
        {
            _notificacoes.Add(new NotificacaoEntity(key, message, retorno));
        }

        public void Adicionar(NotificacaoEntity notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public void Adicionar(IReadOnlyCollection<NotificacaoEntity> notifications)
        {
            _notificacoes.AddRange(notifications);
        }

        public void Adicionar(IList<NotificacaoEntity> notifications)
        {
            _notificacoes.AddRange(notifications);
        }

        public void Adicionar(ICollection<NotificacaoEntity> notifications)
        {
            _notificacoes.AddRange(notifications);
        }

        public void Adicionar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Adicionar(error.PropertyName, error.ErrorMessage, RetornoEnum.Inconsistencia);
            }
        }
    }
}