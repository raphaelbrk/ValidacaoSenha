using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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