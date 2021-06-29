using Microsoft.Extensions.DependencyInjection;
using Validacao.Senha.Infrastructure.Context;
using Validacao.Senha.Infrastructure.Interfaces;
using Validacao.Senha.Infrastructure.Persistence;
using Validacao.Senha.Infrastructure.Repositories;
using Validacao.Senha.Infrastructure.UoW;

namespace Validacao.Senha.Infrastructure
{
    /// <summary>
    /// Classe responsável por injetar as depedências do projeto Validacao.Senha.Infrastructure.
    /// </summary>
    public static class DependencyInjection
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            MongoDbPersistence.Configure();

            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISenhaRepository, SenhaRepository>();
        }
    }
}