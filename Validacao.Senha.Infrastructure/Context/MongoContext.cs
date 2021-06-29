using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Validacao.Senha.Infrastructure.Interfaces;

namespace Validacao.Senha.Infrastructure.Context
{
    /// <summary>
    /// Classe responsável em criar o contexto de conexão ao MongoDB.
    /// </summary>
    /// <seealso cref="Validacao.Senha.Infrastructure.Interfaces.IMongoContext" />
    public class MongoContext : IMongoContext
    {
        private readonly List<Func<Task>> _comandos;
        private readonly IConfiguration _configuration;

        public MongoContext(IConfiguration configuration)
        {
            _configuration = configuration;

            // Every command will be stored and it'll be processed at Salvar
            _comandos = new List<Func<Task>>();
        }

        public MongoClient MongoClient { get; set; }
        public IClientSessionHandle Sessao { get; set; }
        private IMongoDatabase Database { get; set; }

        public void AdicionarComando(Func<Task> func)
        {
            _comandos.Add(func);
        }

        public void Dispose()
        {
            Sessao?.Dispose();
            GC.SuppressFinalize(this);
        }

        public IMongoCollection<T> ObterColecao<T>(string name)
        {
            ConfigurarMongo();

            return Database.GetCollection<T>(name);
        }

        public async Task<int> Salvar()
        {
            ConfigurarMongo();

            using (Sessao = await MongoClient.StartSessionAsync())
            {
                Sessao.StartTransaction();

                var commandTasks = _comandos.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Sessao.CommitTransactionAsync();
            }

            return _comandos.Count;
        }

        private void ConfigurarMongo()
        {
            if (MongoClient != null)
            {
                return;
            }

            MongoClient = new MongoClient(_configuration["MongoSettings:Connection"]);

            Database = MongoClient.GetDatabase(_configuration["MongoSettings:DatabaseName"]);
        }
    }
}