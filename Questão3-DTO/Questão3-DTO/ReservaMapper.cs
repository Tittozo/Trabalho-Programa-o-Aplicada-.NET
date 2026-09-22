using System;
using System.Collections.Generic;
using System.Text;

namespace Questao3_DTO
{
    // Responsável por transformar uma Reserva em RelatorioReservaDto.
    public class ReservaMapper
    {
        // Recebe uma reserva e retorna os dados necessários para o relatório.
        public static RelatorioReservaDto Mapear(Reserva reserva)
        {
            // Calcula o valor total multiplicando as diárias pelo valor da diária.
            decimal valorTotal = reserva.QuantidadeDiarias * reserva.ValorDiaria;

            // Cria e retorna o DTO com os dados que serão apresentados.
            return new RelatorioReservaDto(
                reserva.NomeHospede,
                reserva.NumeroQuarto,
                reserva.QuantidadeDiarias,
                valorTotal,
                "Reserva confirmada"
            );
        }
    }
}