using Validacao.Senha.Application.Base;

namespace Validacao.Senha.Application.Query
{
    /// <summary>
    /// Classe responsável em consultar para geração do token JWT.
    /// </summary>
    /// <seealso cref="Validacao.Senha.Application.Base.GerarTokenSenhaQuery" />
    public class GerarTokenSenhaQuery : BaseSenhaQueryCommand
    {
        public GerarTokenSenhaQuery(string conteudo) : base(conteudo)
        {
        }
    }
}