using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace Validacao.Senha.Domain.Enums
{
    /// <summary>
    /// Enumerador responsável em verificar os códigos de error das validações.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CodigoErrorValidacaoEnum
    {
        [Description("SUCESSO-01")]
        Error01 = 1,

        [Description("ERROR-02")]
        Error02,

        [Description("ERROR-03")]
        Error03,

        [Description("ERROR-04")]
        Error04,

        [Description("ERROR-05")]
        Error05,

        [Description("ERROR-06")]
        Error06,

        [Description("ERROR-0")]
        Error07,
    }
}