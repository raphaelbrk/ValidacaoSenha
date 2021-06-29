using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using Validacao.Senha.Infrastructure.Mappings;

namespace Validacao.Senha.Infrastructure.Persistence
{
    /// <summary>
    /// Classe responsável em criar as configurações de persistência ao MongoDB.
    /// </summary>
    public static class MongoDbPersistence
    {
        public static void Configure()
        {
            SenhaMap.Configure();

            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            // Conventions
            var pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfDefaultConvention(true)
            };
            ConventionRegistry.Register("ValidacaoSenha", pack, t => true);
        }
    }
}