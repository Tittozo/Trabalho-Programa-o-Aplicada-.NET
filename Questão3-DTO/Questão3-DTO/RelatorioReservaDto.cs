using System;
using System.Collections.Generic;
using System.Text;

namespace Questao3_DTO
{
    // DTO utilizado para transportar somente os dados do relatório da reserva.
    public record RelatorioReservaDto(
        // Nome do hóspede.
        string NomeHospede,

        // Número do quarto.
        int NumeroQuarto,

        // Quantidade de diárias.
        int QuantidadeDiarias,

        // Valor total da reserva.
        decimal ValorTotal,

        // Situação da reserva.
        string Situacao
    );
}