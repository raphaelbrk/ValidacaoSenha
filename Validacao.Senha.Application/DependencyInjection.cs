using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Validacao.Senha.Application.Context;
using Validacao.Senha.Application.Interfaces;

namespace Validacao.Senha.Application
{
    /// <summary>
    /// Classe responsável por injetar as depedências do projetoo Application.
    /// </summary>
    public static class DependencyInjection
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped<INotificacaoContext, NotificacaoContext>();
            services.AddMediatR(typeof(DependencyInjection).Assembly);
        }
    }
}