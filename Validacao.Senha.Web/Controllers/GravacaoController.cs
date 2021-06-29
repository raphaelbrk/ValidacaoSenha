using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Validacao.Senha.Application.Command;

namespace Validacao.Senha.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GravacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GravacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Posts the specified comando.
        /// </summary>
        /// <param name="comando">The comando.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] GravacaoSenhaCommand comando)
        {
            var id = await _mediator.Send(comando);
            return Ok(id);
        }
    }
}