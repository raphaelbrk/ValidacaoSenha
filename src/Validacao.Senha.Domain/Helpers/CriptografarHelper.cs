using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Validacao.Senha.Domain.Constantes;
using Validacao.Senha.Domain.Enums;
using Validacao.Senha.Domain.Exceptions;
using Validacao.Senha.Domain.Extensions;

namespace Validacao.Senha.Domain.Helpers
{
    /// <summary>
    /// Classe ajudante responsável em criptografar a senha enviada do usuário através da API.
    /// </summary>
    public static class CriptografarHelper
    {
        public static string Criptografar(this string senha)
        {
            if (string.IsNullOrWhiteSpace(senha)) return string.Empty;

            if (senha.EhNuloOuExisteEspaco()) throw new EncriptacaoPossuiEspacoException(AcaoEncryptionEnum.Criptografar);

            byte[] clearBytes = Encoding.Unicode.GetBytes(senha);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(SenhaConstantes.INCREMENTO_SENHA, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    senha = Convert.ToBase64String(ms.ToArray());
                }
            }

            return senha;
        }
    }
}