using System;
using System.Collections.Generic;
using System.Text;

namespace Questao2_Reflection
{
    public class Equipamento
    {
        // Identificador do equipamento.
        public int Id { get; set; }

        // Nome do equipamento.
        [Exibir]
        public string Nome { get; set; }

        // Fabricante do equipamento.
        [Exibir]
        public string Fabricante { get; set; }

        // Número de série do equipamento.
        public string NumeroSerie { get; set; }

        // Valor do equipamento.
        [Exibir]
        public decimal Valor { get; set; }

        // Localização onde o equipamento está.
        [Exibir]
        public string Localizacao { get; set; }
    }
}