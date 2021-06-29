using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Validacao.Senha.Domain.Entities;
using Validacao.Senha.Domain.Enums;
using Validacao.Senha.Domain.Exceptions;
using Validacao.Senha.Domain.Extensions;
using Validacao.Senha.Web.ViewModel;
using System.Linq;

namespace Validacao.Senha.Web.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case EncriptacaoPossuiEspacoException e:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;

                    case EnumDescricaoNuloReferenceException e:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;

                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var retorno = new NotificacaoEntity(CodigoErrorValidacaoEnum.ErrorGlobal01.ObterDescricao(),
                    error?.Message, RetornoEnum.Inconsistencia);
                var resultado = JsonSerializer.Serialize(new RetornoViewModel(retorno.CriaLista()));
                await response.WriteAsync(resultado);
            }
        }
    }
}