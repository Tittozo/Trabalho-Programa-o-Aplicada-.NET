namespace Questao3_DTO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("       SISTEMA DE RESERVA DE HOTEL");
            Console.WriteLine("========================================");
            Console.WriteLine();

            // Solicita o nome do hóspede.
            Console.Write("Nome do hóspede: ");
            string nomeHospede = Console.ReadLine();

            // Solicita o número do quarto.
            Console.Write("Número do quarto: ");
            int numeroQuarto;

            while (!int.TryParse(Console.ReadLine(), out numeroQuarto))
            {
                Console.Write("Digite um número de quarto válido: ");
            }

            // Solicita a quantidade de diárias.
            Console.Write("Quantidade de diárias: ");
            int quantidadeDiarias;

            while (!int.TryParse(Console.ReadLine(), out quantidadeDiarias))
            {
                Console.Write("Digite uma quantidade válida: ");
            }

            // Solicita o valor da diária.
            Console.Write("Valor da diária: R$ ");
            decimal valorDiaria;

            while (!decimal.TryParse(Console.ReadLine(), out valorDiaria))
            {
                Console.Write("Digite um valor válido: R$ ");
            }

            Console.WriteLine();

            // Solicita informações internas da reserva.
            Console.Write("Status interno: ");
            string statusInterno = Console.ReadLine();

            Console.Write("Observação interna: ");
            string observacaoInterna = Console.ReadLine();

            Console.WriteLine();

            // Cria a reserva com os dados informados pelo usuário.
            Reserva reserva = new Reserva
            {
                Id = 1,
                NomeHospede = nomeHospede,
                NumeroQuarto = numeroQuarto,
                QuantidadeDiarias = quantidadeDiarias,
                ValorDiaria = valorDiaria,
                StatusInterno = statusInterno,
                ObservacaoInterna = observacaoInterna
            };

            // Converte a reserva para o DTO do relatório.
            RelatorioReservaDto relatorio = ReservaMapper.Mapear(reserva);

            // Exibe o relatório utilizando os dados do DTO.
            ExibirRelatorio(relatorio);

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        // Exibe somente as informações presentes no DTO.
        public static void ExibirRelatorio(RelatorioReservaDto relatorio)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("          RELATÓRIO DA RESERVA");
            Console.WriteLine("========================================");

            // Exibe o nome do hóspede.
            Console.WriteLine($"Nome do hóspede: {relatorio.NomeHospede}");

            // Exibe o número do quarto.
            Console.WriteLine($"Número do quarto: {relatorio.NumeroQuarto}");

            // Exibe a quantidade de diárias.
            Console.WriteLine($"Quantidade de diárias: {relatorio.QuantidadeDiarias}");

            // Exibe o valor total calculado pelo Mapper.
            Console.WriteLine($"Valor total: R$ {relatorio.ValorTotal:F2}");

            // Exibe a situação da reserva.
            Console.WriteLine($"Situação: {relatorio.Situacao}");
        }
    }
}