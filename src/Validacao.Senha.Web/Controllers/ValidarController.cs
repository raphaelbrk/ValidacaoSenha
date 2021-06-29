using MediatR;
using Validacao.Senha.Application.Query;

namespace Validacao.Senha.Web.Controllers
{
    /// <summary>
    /// Controller responsável em obter as requisições para a validação da senha enviado para o usuário.
    /// </summary>
    /// <seealso cref="Validacao.Senha.Web.Controllers.BaseController{Validacao.Senha.Application.Query.ValidarSenhaQuery}" />
    public class ValidarController : BaseController<ValidarSenhaQuery>
    {
        public ValidarController(IMediator mediator) : base(mediator)
        {
        }
    }
}