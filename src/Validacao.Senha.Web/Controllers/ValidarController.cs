using MediatR;
using Validacao.Senha.Application.Query;

namespace Validacao.Senha.Web.Controllers
{
    public class ValidarController : BaseController<ValidarSenhaQuery>
    {
        public ValidarController(IMediator mediator) : base(mediator)
        {
        }
    }
}