using System;
using System.Collections.Generic;
using System.Text;

namespace Questao3_DTO
{
    // Representa os dados completos de uma reserva.
    public class Reserva
    {
        // Identificador da reserva.
        public int Id { get; set; }

        // Nome do hóspede.
        public string NomeHospede { get; set; }

        // Número do quarto reservado.
        public int NumeroQuarto { get; set; }

        // Quantidade de diárias da reserva.
        public int QuantidadeDiarias { get; set; }

        // Valor de uma diária.
        public decimal ValorDiaria { get; set; }

        // Status utilizado internamente pelo sistema.
        public string StatusInterno { get; set; }

        // Observação utilizada internamente pelo sistema.
        public string ObservacaoInterna { get; set; }
    }
}