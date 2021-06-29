using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Validacao.Senha.Domain.Exceptions;

namespace Validacao.Senha.Domain.Extensions
{
    /// <summary>
    /// Classe de extensão responsável em obter a descrição do enumerador.
    /// </summary>
    public static class EnumExtensions
    {
        public static string ObterDescricao(this Enum @enum)
        {
            if (@enum.EhNulo()) throw new EnumDescricaoNuloReferenceException();

            MemberInfo[] member = @enum.GetType().GetMember(@enum.ToString());
            string str = (string)null;
            if (member.Length != 0)
            {
                object[] customAttributes1 = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (customAttributes1.Length != 0)
                {
                    str = ((DescriptionAttribute)customAttributes1[0]).Description;
                }
                else
                {
                    object[] customAttributes2 = member[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                    if (customAttributes2.Length != 0)
                        str = ((DisplayAttribute)customAttributes2[0]).Name;
                }
            }

            return str ?? @enum.ToString();
        }
    }
}