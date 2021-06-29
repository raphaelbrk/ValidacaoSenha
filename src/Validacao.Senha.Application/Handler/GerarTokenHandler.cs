using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Validacao.Senha.Application.Authorization;
using Validacao.Senha.Application.Query;

namespace Validacao.Senha.Application.Handler
{
    /// <summary>
    /// Classe responsável em receber as informações da query de geração do token JWT.
    /// </summary>
    /// <seealso cref="Guid" />
    internal class GerarTokenHandler : IRequestHandler<GerarTokenSenhaQuery, object>
    {
        private readonly ITokenAuthorization _tokenAuthorization;

        public GerarTokenHandler(ITokenAuthorization tokenAuthorization)
        {
            _tokenAuthorization = tokenAuthorization;
        }

        public async Task<object> Handle(GerarTokenSenhaQuery request, CancellationToken cancellationToken)
        {
            return _tokenAuthorization.Gerar();
        }
    }
}