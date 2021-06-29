using System.Collections.Generic;
using System.Linq;
using Validacao.Senha.Domain.Entities;
using Validacao.Senha.Domain.Enums;

namespace Validacao.Senha.Web.ViewModel
{
    public class RetornoViewModel
    {
        public List<NotificacaoEntity> Notificacoes;

        public RetornoViewModel(List<NotificacaoEntity> notificacao)
        {
            Notificacoes = notificacao;
        }

        public bool Valido => Notificacoes?.Any(x => x.Retorno.Equals(RetornoEnum.Sucesso)) is true;
    }
}