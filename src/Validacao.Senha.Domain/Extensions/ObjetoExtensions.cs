using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Validacao.Senha.Domain.Extensions
{
    /// <summary>
    /// Classe de extensão responsável em validar se o objeto é nulo ou não e converter o objeto para StringContent.
    /// </summary>
    public static class ObjetoExtensions
    {
        public static StringContent ToStringContent(this object @object)
        {
            return new StringContent(JsonConvert.SerializeObject(@object), Encoding.UTF8, "application/json");
        }

        public static bool EhNulo(this object @object)
        {
            return @object is null;
        }

        public static bool NaoEhNulo(this object @object)
        {
            return @object is not null;
        }

        public static List<T> CriaLista<T>(this T @object)
        {
            if (@object is null)
                return new();

            return new() { @object };
        }
    }
}