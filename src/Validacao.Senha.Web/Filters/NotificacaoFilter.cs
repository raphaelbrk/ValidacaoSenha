using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Validacao.Senha.Application.Interfaces;
using Validacao.Senha.Web.ViewModel;

namespace Validacao.Senha.Web.Filters
{
    /// <summary>
    /// Classe responsável em filtrar e retornar as notificações das validações.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter" />
    public class NotificacaoFilter : IAsyncResultFilter
    {
        private readonly INotificacaoContext _notificacaoContext;

        public NotificacaoFilter(INotificacaoContext notificacaoContext)
        {
            _notificacaoContext = notificacaoContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificacaoContext.EhNotificacoesComErro)
            {
                await ObterRetorno(context, HttpStatusCode.BadRequest);
                return;
            }
            else if (_notificacaoContext.EhNotificacaoComSucesso)
            {
                await ObterRetorno(context, HttpStatusCode.OK);
                return;
            }

            await next();
        }

        private async Task ObterRetorno(ResultExecutingContext context, HttpStatusCode statusCode)
        {
            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.HttpContext.Response.ContentType = "application/json";

            var retorno = new RetornoViewModel(_notificacaoContext.Notificacoes?.ToList());

            var notifications = JsonConvert.SerializeObject(retorno);
            await context.HttpContext.Response.WriteAsync(notifications);
        }
    }
}