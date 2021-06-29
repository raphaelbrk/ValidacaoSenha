using System;
using System.Linq;

namespace Validacao.Senha.Domain.Extensions
{
    /// <summary>
    /// Classe de extensão responsável em verificar strings.
    /// </summary>
    public static class StringExtensions
    {
        public static bool EhNuloOuExisteEspaco(this string str)
        {
            if (str is null) return false;
            if (string.IsNullOrWhiteSpace(str)) return false;

            return str.Any(Char.IsWhiteSpace);
        }
    }
}