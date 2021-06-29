namespace Validacao.Senha.Domain.Constantes
{
    /// <summary>
    /// Classe responsável em guardar as formulas regex das validações do projeto.
    /// </summary>
    public static class RegexConstantes
    {
        public static string REGEX_PELO_MENOS_UM_CARACTER_ESPECIAL = "^(?=.*[!@#$%^&*()-+])";
        public static string REGEX_PELO_MENOS_UM_NUMERO = "^(?=.*[0-9])";
        public static string REGEX_PELO_MENOS_UMA_LETRA_MAIUSCULA = "^(?=.*[A-Z])";
        public static string REGEX_PELO_MENOS_UMA_LETRA_MINUSCULA = "^(?=.*[a-z])";
        public static string REGEX_CARACTER_REPETIDO = @"(\w)(\1+)";
    }
}