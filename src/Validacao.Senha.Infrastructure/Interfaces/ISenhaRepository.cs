using Validacao.Senha.Domain.Entities;

namespace Validacao.Senha.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface criada para a execução dos comandos na coleção Password.
    /// </summary>
    /// <seealso cref="Validacao.Senha.Infrastructure.Interfaces.IRepository{Validacao.Senha.Domain.Entities.SenhaEntity}" />
    public interface ISenhaRepository : IRepository<SenhaEntity>
    {
    }
}