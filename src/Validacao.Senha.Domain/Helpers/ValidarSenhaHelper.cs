using System.Text.RegularExpressions;

namespace Validacao.Senha.Domain.Helpers
{
    /// <summary>
    /// Classe ajudante responsável em validar o regex da senha enviada do usuário através da API.
    /// </summary>
    public static class ValidarSenhaHelper
    {
        public static bool Validar(this string senha, string regex, bool considerarCaseSensitive = false)
        {
            var valor = senha.Descriptografar();

            valor = considerarCaseSensitive ? valor.ToLower() : valor;

            var match = Regex.Match(valor, regex);

            return match.Success;
        }
    }
}