using Validacao.Senha.Application.Base;

namespace Validacao.Senha.Application.Query
{
    /// <summary>
    /// Classe responsável em consultar se a senha que foi enviado pelo usuário através do request do usuário.
    /// </summary>
    /// <seealso cref="Validacao.Senha.Application.Base.BaseSenhaQueryCommand" />
    public class ValidacaoSenhaQuery : BaseSenhaQueryCommand
    {
        public ValidacaoSenhaQuery(string conteudo) : base(conteudo)
        {
        }
    }
}