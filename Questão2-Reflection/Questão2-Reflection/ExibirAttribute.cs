using System;

namespace Questao2_Reflection
{
    // Define que o atributo [Exibir] só pode ser usado em propriedades.
    [AttributeUsage(AttributeTargets.Property)]
    public class ExibirAttribute : Attribute
    {
    }
}