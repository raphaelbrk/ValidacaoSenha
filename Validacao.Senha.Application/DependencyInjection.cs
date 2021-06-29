using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Validacao.Senha.Application.Authorization;
using Validacao.Senha.Application.Context;
using Validacao.Senha.Application.Interfaces;

namespace Validacao.Senha.Application
{
    /// <summary>
    /// Classe responsável por injetar as depedências do projetoo Application.
    /// </summary>
    public static class DependencyInjection
    {
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INotificacaoContext, NotificacaoContext>();
            services.AddScoped<IGerarTokenAuthorization, GerarTokenAuthorization>();
            services.AddMediatR(typeof(DependencyInjection).Assembly);

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Emissor"],
                        ValidAudience = configuration["Jwt:Publico"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Chave"]))
                    };
                });
        }
    }
}