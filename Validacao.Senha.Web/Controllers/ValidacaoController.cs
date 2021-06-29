using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Validacao.Senha.Application.Query;

namespace Validacao.Senha.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ValidacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Endpoint para validação da senha.
        /// </summary>
        /// <param name="query">Dados da senha.</param>
        /// <returns>retorno validação das senhas</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] ValidacaoSenhaQuery query)
        {
            var id = await _mediator.Send(query);
            return Ok(id);
        }
    }
}