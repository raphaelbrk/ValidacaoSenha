using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Validacao.Senha.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface criada para a classe do contexto ao banco MongoDB.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IMongoContext : IDisposable
    {
        void AdicionarComando(Func<Task> func);

        Task<int> Salvar();

        IMongoCollection<T> ObterColecao<T>(string name);
    }
}