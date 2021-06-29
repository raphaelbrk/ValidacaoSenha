using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace Validacao.Senha.Domain.Enums
{
    /// <summary>
    /// Enumerador responsável em verificar se as validações retornadas para o usuário foram feitas com sucesso ou com inconsistencia.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RetornoEnum
    {
        [Description("Sucesso")]
        Sucesso = 1,

        [Description("Inconsistência")]
        Inconsistencia
    }
}