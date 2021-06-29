using FluentValidation;
using Validacao.Senha.Domain.Constantes;
using Validacao.Senha.Domain.Entities;
using Validacao.Senha.Domain.Enums;
using Validacao.Senha.Domain.Extensions;
using Validacao.Senha.Domain.Helpers;

namespace Validacao.Senha.Domain.Validations
{
    /// <summary>
    /// Classe responsável em fazer as validações da senha enviado pelo usuário através da Api.
    /// As seguintes regras são executadas.
    /// Nove ou mais caracteres.
    /// Ao menos 1 dígito.
    /// Ao menos 1 letra minúscula.
    /// Ao menos 1 letra maiúscula.
    /// Ao menos 1 caractere especial.
    /// Considere como especial os seguintes caracteres: !@#$%^&*()-+
    /// Não possuir caracteres repetidos dentro do conjunto.
    /// Não possuir espaço na senha.
    /// </summary>
    /// <seealso cref="SenhaEntity" />
    public class SenhaValidator : AbstractValidator<SenhaEntity>
    {
        public SenhaValidator()
        {
            ValidarSenhaNaoInformarda();
            ValidarSenhaPeloMenosUmDigitoNumerico();
            ValidarSenhaPeloMenosUmaLetraMaiuscula();
            ValidarSenhaPeloMenosUmaLetraMinuscula();
            ValidarSenhaPeloMenosUmCaracterEspecial();
            ValidarSenhaCaracterRepetido();
            ValidarSenhaComEspaco();
            ValidarSenhaComMaisOuIgualNoveCaracter();
        }

        #region "Validações"

        private void ValidarSenhaCaracterRepetido()
        {
            RuleFor(a => a.ConteudoCriptografado)
                .Must(x => !x.Validar(RegexConstantes.REGEX_CARACTER_REPETIDO, true))
                .WithMessage(MensagensConstantes.SENHA_COM_CARACTER_REPETIDO)
                .OverridePropertyName(CodigoErrorValidacaoEnum.Error06.ObterDescricao());
        }

        private void ValidarSenhaComEspaco()
        {
            RuleFor(a => a.Conteudo)
                .Must(x => !x.EhNuloOuExisteEspaco())
                .When(x => !string.IsNullOrWhiteSpace(x.Conteudo))
                .WithMessage(MensagensConstantes.SENHA_COM_ESPACO)
                .OverridePropertyName(CodigoErrorValidacaoEnum.Error07.ObterDescricao());
        }

        private void ValidarSenhaComMaisOuIgualNoveCaracter()
        {
            RuleFor(a => a.ConteudoCriptografado)
                .Must(x => x.Validar(RegexConstantes.REGEX_IGUAL_NOVE_OU_MAIS_CARACTERES))
                .WithMessage(MensagensConstantes.SENHA_COM_MENOS_NOVE_CARACTERES)
                .OverridePropertyName(CodigoErrorValidacaoEnum.Error08.ObterDescricao());
        }

        private void ValidarSenhaNaoInformarda()
        {
            RuleFor(a => a.ConteudoCriptografado)
                .NotEmpty()
                .WithMessage(MensagensConstantes.SENHA_NAO_INFORMADA)
                .OverridePropertyName(CodigoErrorValidacaoEnum.Error01.ObterDescricao());
        }

        private void ValidarSenhaPeloMenosUmaLetraMaiuscula()
        {
            RuleFor(a => a.ConteudoCriptografado)
                .Must(x => x.Validar(RegexConstantes.REGEX_PELO_MENOS_UMA_LETRA_MAIUSCULA))
                .WithMessage(MensagensConstantes.SENHA_PELO_MENOS_UMA_LETRA_MAIUSCULA)
                .OverridePropertyName(CodigoErrorValidacaoEnum.Error02.ObterDescricao());
        }

        private void ValidarSenhaPeloMenosUmaLetraMinuscula()
        {
            RuleFor(a => a.ConteudoCriptografado)
                .Must(x => x.Validar(RegexConstantes.REGEX_PELO_MENOS_UMA_LETRA_MINUSCULA))
                .WithMessage(MensagensConstantes.SENHA_PELO_MENOS_UMA_LETRA_MINUSCULA)
                .OverridePropertyName(CodigoErrorValidacaoEnum.Error03.ObterDescricao());
        }

        private void ValidarSenhaPeloMenosUmCaracterEspecial()
        {
            RuleFor(a => a.ConteudoCriptografado)
                .Must(x => x.Validar(RegexConstantes.REGEX_PELO_MENOS_UM_CARACTER_ESPECIAL))
                .WithMessage(MensagensConstantes.SENHA_PELO_MENOS_UM_CARACTER_ESPECIAL)
                .OverridePropertyName(CodigoErrorValidacaoEnum.Error04.ObterDescricao());
        }

        private void ValidarSenhaPeloMenosUmDigitoNumerico()
        {
            RuleFor(a => a.ConteudoCriptografado)
                .Must(x => x.Validar(RegexConstantes.REGEX_PELO_MENOS_UM_NUMERO))
                .WithMessage(MensagensConstantes.SENHA_PELO_MENOS_UM_DIGITO_NUMERICO)
                .OverridePropertyName(CodigoErrorValidacaoEnum.Error05.ObterDescricao());
        }

        #endregion "Validações"
    }
}