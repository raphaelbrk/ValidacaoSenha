using Validacao.Senha.Application.Base;

namespace Validacao.Senha.Application.Query
{
    /// <summary>
    /// Classe responsável em consultar se a senha que foi enviado pelo usuário através do request do usuário.
    /// </summary>
    /// <seealso cref="Validacao.Senha.Application.Base.BaseSenhaQueryCommand" />
    public class ValidarSenhaQuery : BaseSenhaQueryCommand<object>
    {
        public ValidarSenhaQuery(string conteudo) : base(conteudo)
        {
        }
    }
}