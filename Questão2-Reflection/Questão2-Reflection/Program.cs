using System.Reflection;

namespace Questao2_Reflection
{
    internal class Program
    {
        // Exibe todas as propriedades públicas do objeto.
        public static void ExibirDadosAberto(object objeto)
        {
            // Obtém o tipo do objeto.
            Type tipo = objeto.GetType();

            // Obtém todas as propriedades públicas.
            PropertyInfo[] propriedades = tipo.GetProperties();

            Console.WriteLine("=== EXIBIÇÃO ABERTA ===");

            foreach (PropertyInfo propriedade in propriedades)
            {
                // Obtém o valor da propriedade.
                object valor = propriedade.GetValue(objeto);

                Console.WriteLine($"{propriedade.Name}: {valor}");
            }
        }

        // Exibe somente as propriedades marcadas com [Exibir].
        public static void ExibirDadosControlado(object objeto)
        {
            // Obtém o tipo do objeto.
            Type tipo = objeto.GetType();

            // Obtém todas as propriedades públicas.
            PropertyInfo[] propriedades = tipo.GetProperties();

            Console.WriteLine("=== EXIBIÇÃO CONTROLADA ===");

            foreach (PropertyInfo propriedade in propriedades)
            {
                // Verifica se a propriedade possui o atributo [Exibir].
                ExibirAttribute atributo = propriedade.GetCustomAttribute<ExibirAttribute>();

                if (atributo != null)
                {
                    // Obtém o valor da propriedade.
                    object valor = propriedade.GetValue(objeto);

                    Console.WriteLine($"{propriedade.Name}: {valor}");
                }
            }
        }

        static void Main(string[] args)
        {
            // Cria um equipamento para realizar os testes.
            Equipamento equipamento = new Equipamento
            {
                Id = 1,
                Nome = "Notebook",
                Fabricante = "Dell",
                NumeroSerie = "DL123456",
                Valor = 3500.00m,
                Localizacao = "Laboratório de Informática"
            };

            Console.WriteLine("========================================");
            Console.WriteLine("       REFLECTION - EQUIPAMENTO");
            Console.WriteLine("========================================");
            Console.WriteLine();

            // Exibe todas as propriedades.
            ExibirDadosAberto(equipamento);

            Console.WriteLine();

            // Exibe somente as propriedades marcadas com [Exibir].
            ExibirDadosControlado(equipamento);

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}