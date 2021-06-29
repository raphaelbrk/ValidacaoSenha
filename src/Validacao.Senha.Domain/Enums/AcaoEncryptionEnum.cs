using System.ComponentModel;

namespace Validacao.Senha.Domain.Enums
{
    /// <summary>
    /// Enumerador responsável em execução a ação da validação da senha.
    /// </summary>
    public enum AcaoEncryptionEnum
    {
        [Description("Criptografar")]
        Criptografar = 1,

        [Description("Descriptografar")]
        Descriptografar
    }
}