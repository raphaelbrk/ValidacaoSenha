using Validacao.Senha.Domain.Entities;
using Validacao.Senha.Infrastructure.Interfaces;

namespace Validacao.Senha.Infrastructure.Repositories
{
    /// <summary>
    /// Classe responsável pela implementação dos comandos de execução da coleção Senha ao mongoDB.
    /// </summary>
    /// <seealso cref="Validacao.Senha.Infrastructure.Repositories.BaseRepository{Validacao.Senha.Domain.Entities.SenhaEntity}" />
    /// <seealso cref="ISenhaRepository" />
    public class SenhaRepository : BaseRepository<SenhaEntity>, ISenhaRepository
    {
        public SenhaRepository(IMongoContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}