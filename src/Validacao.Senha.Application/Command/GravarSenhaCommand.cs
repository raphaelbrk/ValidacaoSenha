using Validacao.Senha.Application.Base;

namespace Validacao.Senha.Application.Command
{
    /// <summary>
    /// Classe responsável em guardar as infrmações do comando que enviado do projeto da API para Application.
    /// </summary>
    /// <seealso cref="Validacao.Senha.Application.Base.BaseSenhaQueryCommand" />
    public class GravarSenhaCommand : BaseSenhaQueryCommand<object>
    {
        public GravarSenhaCommand(string conteudo) : base(conteudo)
        {
        }
    }
}