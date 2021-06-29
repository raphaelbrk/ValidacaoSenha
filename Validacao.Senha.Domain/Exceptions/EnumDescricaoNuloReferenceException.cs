using System;

namespace Validacao.Senha.Domain.Exceptions
{
    /// <summary>
    /// Classe responsável em criar uma excpetion customizada para quando a descrição do Enumerador AcaoEncryptionEnum for nulo.
    /// </summary>
    /// <seealso cref="System.NullReferenceException" />
    public class EnumDescricaoNuloReferenceException : NullReferenceException
    {
        public EnumDescricaoNuloReferenceException()
            : base($"O enumerador não pode ser nulo.")
        {
        }
    }
}