using MediatR;
using Validacao.Senha.Application.Command;

namespace Validacao.Senha.Web.Controllers
{
    /// <summary>
    /// Controller responsável em obter as requisições para a gravação de senha.
    /// </summary>
    /// <seealso cref="Validacao.Senha.Web.Controllers.BaseController{Validacao.Senha.Application.Command.GravarSenhaCommand}" />
    public class GravarSenhaController : BaseController<GravarSenhaCommand>
    {
        public GravarSenhaController(IMediator mediator) : base(mediator)
        {
        }
    }
}