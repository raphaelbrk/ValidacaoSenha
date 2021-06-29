using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using System;

namespace Validacao.Senha.Domain.Entities
{
    /// <summary>
    /// Classe responsável em guardar as informações base das entidades do projeto.
    /// </summary>
    /// <typeparam name="TEntity">Qualquer tipo que é class.</typeparam>
    /// <seealso cref="Validacao.Senha.Domain.Entities.BaseAbstractEntity" />
    public class BaseEntity<TEntity> : BaseAbstractEntity where TEntity : class
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        [JsonIgnore]
        public bool Invalido => !Valido;

        [JsonIgnore]
        public ValidationResult ValidacaoResult { get; private set; }

        [JsonIgnore] public bool Valido { get; private set; } = true;

        protected bool Validar<TEntity>(TEntity model, AbstractValidator<TEntity> validator)
        {
            ValidacaoResult = validator.Validate(model);
            Valido = ValidacaoResult.IsValid;
            return Valido;
        }
    }
}