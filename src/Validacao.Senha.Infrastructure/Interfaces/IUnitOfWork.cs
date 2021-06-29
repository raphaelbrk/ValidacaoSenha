using System;
using System.Threading.Tasks;

namespace Validacao.Senha.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface criada para a classe do padrão de projeto de transação coordenada ao MongoDB.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Comitar();
    }
}