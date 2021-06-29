using MediatR;
using Validacao.Senha.Application.Command;

namespace Validacao.Senha.Web.Controllers
{
    public class GravarSenhaController : BaseController<GravarSenhaCommand>
    {
        public GravarSenhaController(IMediator mediator) : base(mediator)
        {
        }
    }
}