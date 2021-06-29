using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Validacao.Senha.Application.Authorization;

namespace Validacao.Senha.Application.Interfaces
{
    /// <summary>
    /// Classe responsável para geração do token JWT.
    /// </summary>
    public class GerarTokenAuthorization : IGerarTokenAuthorization
    {
        private readonly IConfiguration _configuration;

        public GerarTokenAuthorization(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public string Gerar()
        {
            var issuer = _configuration["Jwt:Emissor"];
            var audience = _configuration["Jwt:Publico"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Chave"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience,
                expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);

            return $"bearer {stringToken}";
        }
    }
}