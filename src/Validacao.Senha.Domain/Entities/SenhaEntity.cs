using Newtonsoft.Json;
using Validacao.Senha.Domain.Extensions;
using Validacao.Senha.Domain.Helpers;
using Validacao.Senha.Domain.Validations;

namespace Validacao.Senha.Domain.Entities
{
    /// <summary>
    /// Classe responsável em guardar as informações da senha do projeto.
    /// </summary>
    /// <seealso cref="Validacao.Senha.Domain.Entities.BaseEntity{Validacao.Senha.Domain.Entities.SenhaEntity}" />
    public class SenhaEntity : BaseEntity<SenhaEntity>
    {
        public SenhaEntity(string conteudo) : base()
        {
            Conteudo = conteudo;
        }

        public string Conteudo { get; private set; }


        public string ConteudoCriptografado => !Conteudo.EhNuloOuExisteEspaco() ? Conteudo.Criptografar() : string.Empty;

        [JsonIgnore]
        public string ConteudoDescriptografado => !Conteudo.EhNuloOuExisteEspaco() ? Conteudo : string.Empty;

        public override bool Validar()
        {
            return Validar(this, new SenhaValidator());
        }
    }
}