using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Validacao.Senha.Domain.Entities
{
    /// <summary>
    /// Classe abstrata responsável em guardar as informações base das entidades do projeto.
    /// </summary>
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(BaseAbstractEntity))]
    public class BaseAbstractEntity
    {
        [BsonId]
        public virtual Guid Id { get; set; }

        public virtual bool Validar()
        {
            return true;
        }
    }
}