using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Validacao.Senha.Application.Authorization;
using Validacao.Senha.Application.Command;
using Validacao.Senha.Application.Interfaces;
using Validacao.Senha.Application.Query;
using Validacao.Senha.Domain.Constantes;
using Validacao.Senha.Domain.Entities;
using Validacao.Senha.Domain.Enums;
using Validacao.Senha.Domain.Extensions;
using Validacao.Senha.Infrastructure.Interfaces;

namespace Validacao.Senha.Application.Handler
{
    /// <summary>
    /// Classe responsável em receber as informações da query de geração do token JWT.
    /// </summary>
    /// <seealso cref="Guid" />
    internal class GerarTokenHandler : IRequestHandler<GerarTokenSenhaQuery, object>
    {
        private readonly IGerarTokenAuthorization _gerarTokenAuthorization;

        public GerarTokenHandler(IGerarTokenAuthorization gerarTokenAuthorization)
        {
            _gerarTokenAuthorization = gerarTokenAuthorization;
        }

        public async Task<object> Handle(GerarTokenSenhaQuery request, CancellationToken cancellationToken)
        {
            return _gerarTokenAuthorization.Gerar();
        }
    }
}