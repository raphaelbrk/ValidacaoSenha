using System.Collections.Generic;
using System.Linq;
using Validacao.Senha.Domain.Entities;

namespace Validacao.Senha.Web.ViewModel
{
    public class RetornoViewModel
    {
        public IReadOnlyCollection<NotificacaoEntity> Notificacoes;

        public RetornoViewModel(IReadOnlyCollection<NotificacaoEntity> notificacao)
        {
            Notificacoes = notificacao;
        }

        public bool Valido => Notificacoes?.Any(x => x.Valido) is true;
    }
}