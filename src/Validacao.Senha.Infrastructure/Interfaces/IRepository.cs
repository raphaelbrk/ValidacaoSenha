using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Validacao.Senha.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface generica criada para executar os comandos a coleção.
    /// </summary>
    /// <typeparam name="TEntity">Qualquer tipo de class.</typeparam>
    /// <seealso cref="System.IDisposable" />
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity obj);

        Task<TEntity> ObterPorId(Guid id);

        Task<IEnumerable<TEntity>> ObterTodos();

        void Atualizar(TEntity obj);

        void Remover(Guid id);
    }
}