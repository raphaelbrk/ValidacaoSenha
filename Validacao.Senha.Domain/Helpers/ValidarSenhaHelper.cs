using System.Text.RegularExpressions;
using Validacao.Senha.Domain.Extensions;

namespace Validacao.Senha.Domain.Helpers
{
    /// <summary>
    /// Classe ajudante responsável em validar o regex da senha enviada do usuário através da API.
    /// </summary>
    public static class ValidarSenhaHelper
    {
        public static bool Validar(this string senha, string regex)
        {
            var valor = senha.Descriptografar();
            var match = Regex.Match(valor, regex);

            return match.Success;
        }
    }
}