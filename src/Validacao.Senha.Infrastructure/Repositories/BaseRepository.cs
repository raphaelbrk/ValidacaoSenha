using MongoDB.Driver;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Validacao.Senha.Infrastructure.Interfaces;

namespace Validacao.Senha.Infrastructure.Repositories
{
    /// <summary>
    /// Classe responsável para implementar os comandos genericos da coleção ao MongoDB.
    /// </summary>
    /// <typeparam name="TEntity">Qualquer do tipo class.</typeparam>
    /// <seealso cref="Validacao.Senha.Infrastructure.Interfaces.IRepository{TEntity}" />
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext Context;
        protected readonly IUnitOfWork _unitOfWork;
        protected IMongoCollection<TEntity> DbSet;

        protected BaseRepository(
            IMongoContext context,
            IUnitOfWork unitOfWork)
        {
            Context = context;
            _unitOfWork = unitOfWork;
            DbSet = Context.ObterColecao<TEntity>(typeof(TEntity).Name);
        }

        public virtual void Adicionar(TEntity obj)
        {
            Context.AdicionarComando(() => DbSet.InsertOneAsync(obj));
        }

        public virtual void Atualizar(TEntity obj)
        {
            Context.AdicionarComando(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId()), obj));
        }

        public void Dispose()
        {
            _unitOfWork.Comitar();
            Context?.Dispose();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodos()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Remover(Guid id)
        {
            Context.AdicionarComando(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
        }
    }
}