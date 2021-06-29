using System.Text.Json.Serialization;
using Validacao.Senha.Domain.Enums;

namespace Validacao.Senha.Domain.Entities
{
    /// <summary>
    /// Classe responsável em guardar as informações das notificações das validações do projeto.
    /// </summary>
    /// <seealso cref="Validacao.Senha.Domain.Entities.BaseEntity{Validacao.Senha.Domain.Entities.NotificacaoEntity}" />
    public class NotificacaoEntity : BaseEntity<NotificacaoEntity>
    {
        [JsonIgnore]
        public string Chave { get; }

        public string Mensagem { get; }

        public RetornoEnum Retorno { get; set; }

        public NotificacaoEntity() : base()
        {
        }

        public NotificacaoEntity(string chave, string mensagem) : base()
        {
            Chave = chave;
            Mensagem = mensagem;
            Retorno = RetornoEnum.Inconsistencia;
        }

        public NotificacaoEntity(string chave, string mensagem, RetornoEnum retorno) : base()
        {
            Chave = chave;
            Mensagem = mensagem;
            Retorno = retorno;
        }
    }
}