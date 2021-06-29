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
                var commandTasks = _comandos.Select(c => c());

                await Task.WhenAll(commandTasks);
            }

            return _comandos.Count;
        }

        private void ConfigurarMongo()
        {
            if (MongoClient != null)
            {
                return;
            }

            var username = _configuration.GetSection("ConnectionStrings:MongoDB").GetSection("Username").Value;
            var password = _configuration.GetSection("ConnectionStrings:MongoDB").GetSection("Password").Value;
            var mongoDbAuthMechanism = _configuration.GetSection("ConnectionStrings:MongoDB").GetSection("AuthMechanism").Value;
            var databasename = _configuration.GetSection("ConnectionStrings:MongoDB").GetSection("Database").Value;
            var mongoHost = _configuration.GetSection("ConnectionStrings:MongoDB").GetSection("Host").Value;
            var port = Convert.ToInt32(_configuration.GetSection("ConnectionStrings:MongoDB").GetSection("Port").Value);

            var internalIdentity = new MongoInternalIdentity(databasename, username);
            var passwordEvidence = new PasswordEvidence(password);
            var mongoCredential = !string.IsNullOrWhiteSpace(mongoDbAuthMechanism)
                ? new MongoCredential(mongoDbAuthMechanism, internalIdentity, passwordEvidence)
                : null;

            var settings = new MongoClientSettings
            {
                Server = new MongoServerAddress(mongoHost, port)
            };

            if (mongoCredential != null) settings.Credential = mongoCredential;

            MongoClient = new MongoClient(settings);
            Database = MongoClient.GetDatabase(databasename);
        }
    }
}