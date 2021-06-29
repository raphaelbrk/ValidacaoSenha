using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace Validacao.Senha.Domain.Enums
{
    /// <summary>
    /// Enumerador responsável em verificar os códigos de sucesso das validações.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CodigoSucessoValidacaoEnum
    {
        [Description("SUCESSO-01")]
        Sucesso01 = 1
    }
}