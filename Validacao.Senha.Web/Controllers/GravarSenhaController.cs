using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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