namespace Validacao.Senha.Application.Authorization
{
    /// <summary>
    /// Interface responsável para adicionar as notificações das validações do FluentValidation que será retornado para o usuário.
    /// </summary>
    public interface ITokenAuthorization
    {
        public string Gerar();
    }
}