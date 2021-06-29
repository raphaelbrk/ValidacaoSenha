using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Validacao.Senha.Application.Command;
using Validacao.Senha.Application.Query;

namespace Validacao.Senha.Web.Controllers
{
    public class TokenController : BaseController<GerarTokenSenhaQuery>
    {
        public TokenController(IMediator mediator) : base(mediator)
        {
        }
    }
}