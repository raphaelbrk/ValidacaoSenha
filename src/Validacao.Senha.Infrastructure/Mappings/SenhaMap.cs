using MongoDB.Bson.Serialization;
using Validacao.Senha.Domain.Entities;

namespace Validacao.Senha.Infrastructure.Mappings
{
    /// <summary>
    /// Mapping da coleção da Senha do MongoDB.
    /// </summary>
    public class SenhaMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<SenhaEntity>(map =>
            {
                map.AutoMap();
                map.SetIdMember(map.GetMemberMap(a => a.Id));
                map.SetIsRootClass(true);
                map.MapMember(x => x.ConteudoCriptografado).SetIsRequired(true);
            });
        }
    }
}