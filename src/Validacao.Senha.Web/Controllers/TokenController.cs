using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Validacao.Senha.Application.Query;

namespace Validacao.Senha.Web.Controllers
{
    /// <summary>
    /// Controller responsável em obter as requisições para geração do token JWT.
    /// </summary>
    /// <seealso cref="Validacao.Senha.Web.Controllers.BaseController{Validacao.Senha.Application.Query.GerarTokenSenhaQuery}" />
    public class TokenController : BaseController<GerarTokenSenhaQuery>
    {
        public TokenController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var comando = new GerarTokenSenhaQuery(string.Empty);
            var id = await _mediator.Send(comando);
            return Ok(id);
        }
    }
}