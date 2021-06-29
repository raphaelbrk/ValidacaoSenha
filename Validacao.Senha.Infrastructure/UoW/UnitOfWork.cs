using System.Threading.Tasks;
using Validacao.Senha.Infrastructure.Interfaces;

namespace Validacao.Senha.Infrastructure.UoW
{
    /// <summary>
    ///  Classe responsável para transação e coordenada ao MongoDB. 
    /// </summary>
    /// <seealso cref="Validacao.Senha.Infrastructure.Interfaces.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public async Task<bool> Comitar()
        {
            var changeAmount = await _context.Salvar();

            return changeAmount > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}