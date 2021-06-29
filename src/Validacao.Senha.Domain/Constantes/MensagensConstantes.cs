namespace Validacao.Senha.Domain.Constantes
{
    /// <summary>
    /// Classe responsável em guardar as constantes das mensagens das aplicações. Por exemplo: Validações.
    /// </summary>
    public class MensagensConstantes
    {
        public static string SENHA_NAO_INFORMADA = "A senha deve ser informada.";

        public static string SENHA_PELO_MENOS_UM_DIGITO_NUMERICO = "A senha deve ter ao menos 1 dígito númerico.";

        public static string SENHA_PELO_MENOS_UMA_LETRA_MAIUSCULA = "A senha deve ter ao menos 1 letra maiscula.";

        public static string SENHA_PELO_MENOS_UMA_LETRA_MINUSCULA = "A senha deve ter ao menos 1 letra minúscula.";

        public static string SENHA_PELO_MENOS_UM_CARACTER_ESPECIAL = "A senha deve ter ao menos 1 caracter especial.";

        public static string SENHA_COM_CARACTER_REPETIDO = "A senha não deve conter caracter repetido.";

        public static string SENHA_COM_ESPACO = "A senha não deve conter espaço.";

        public static string SENHA_COM_MENOS_NOVE_CARACTERES = "A senha deve conter mais de nove caracter.";

        public static string SENHA_CORRETO = "A senha está correta.";
    }
}