using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Validacao.Senha.Application.Command;
using Validacao.Senha.Application.Query;

namespace Validacao.Senha.Web.Controllers
{
    /// <summary>
    /// Classe base controller.
    /// </summary>
    /// <typeparam name="TEntity">Comandos para a execução da aplicação.</typeparam>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> Post([FromBody] TEntity comando)
        {
            var id = await _mediator.Send(comando);
            return Ok(id);
        }


        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> Get()
        {
            var comando = new GerarTokenSenhaQuery(string.Empty);
            var id = await _mediator.Send(comando);
            return Ok(id);
        }


    }
}
