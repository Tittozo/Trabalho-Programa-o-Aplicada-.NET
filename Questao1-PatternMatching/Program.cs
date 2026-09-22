namespace PatternMatching
{
    internal class Program
    {
        // Verifica se o usuário pode realizar um empréstimo.
        public static string VerificarEmprestimo(object obj)
        {
            return obj switch
            {
                // Usuário nulo.
                null => "Usuário inválido",

                // Aluno com menos de 3 empréstimos.
                Aluno { QuantidadeEmprestimosAtivos: < 3 }
                    => "Empréstimo autorizado para aluno",

                // Aluno com 3 ou mais empréstimos.
                Aluno { QuantidadeEmprestimosAtivos: >= 3 }
                    => "Limite de empréstimos atingido para aluno",

                // Professor com menos de 5 empréstimos.
                Professor { QuantidadeEmprestimosAtivos: < 5 }
                    => "Empréstimo autorizado para professor",

                // Professor com 5 ou mais empréstimos.
                Professor { QuantidadeEmprestimosAtivos: >= 5 }
                    => "Limite de empréstimos atingido para professor",

                // Visitantes não podem realizar empréstimos.
                Visitante => "Visitantes não podem realizar empréstimos",

                // Outros tipos de objetos.
                _ => "Usuário não classificado"
            };
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("       SISTEMA DE EMPRÉSTIMOS - BIBLIOTECA");
            Console.WriteLine("==============================================");
            Console.WriteLine();

            // ==================== ALUNO ====================

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("                 CADASTRO ALUNO");
            Console.WriteLine("----------------------------------------------");

            Console.Write("Nome: ");
            string nomeAluno = Console.ReadLine();

            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine();

            Console.Write("Quantidade de empréstimos ativos: ");

            int emprestimosAluno;

            while (!int.TryParse(Console.ReadLine(), out emprestimosAluno))
            {
                Console.Write("Digite uma quantidade válida: ");
            }

            Aluno aluno = new Aluno
            {
                Nome = nomeAluno,
                Matricula = matricula,
                QuantidadeEmprestimosAtivos = emprestimosAluno
            };

            Console.WriteLine();

            // ================= PROFESSOR =================

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("              CADASTRO PROFESSOR");
            Console.WriteLine("----------------------------------------------");

            Console.Write("Nome: ");
            string nomeProfessor = Console.ReadLine();

            Console.Write("Departamento: ");
            string departamento = Console.ReadLine();

            Console.Write("Quantidade de empréstimos ativos: ");

            int emprestimosProfessor;

            while (!int.TryParse(Console.ReadLine(), out emprestimosProfessor))
            {
                Console.Write("Digite uma quantidade válida: ");
            }

            Professor professor = new Professor
            {
                Nome = nomeProfessor,
                Departamento = departamento,
                QuantidadeEmprestimosAtivos = emprestimosProfessor
            };

            Console.WriteLine();

            // ================= VISITANTE =================

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("              CADASTRO VISITANTE");
            Console.WriteLine("----------------------------------------------");

            Console.Write("Nome: ");
            string nomeVisitante = Console.ReadLine();

            Console.Write("Documento: ");
            string documento = Console.ReadLine();

            Visitante visitante = new Visitante
            {
                Nome = nomeVisitante,
                Documento = documento
            };

            Console.WriteLine();

            // ================= RESULTADOS =================

            Console.WriteLine("==============================================");
            Console.WriteLine("                   RESULTADOS");
            Console.WriteLine("==============================================");

            Console.WriteLine();
            Console.WriteLine("ALUNO");
            Console.WriteLine($"Nome: {aluno.Nome}");
            Console.WriteLine($"Matrícula: {aluno.Matricula}");
            Console.WriteLine($"Empréstimos ativos: {aluno.QuantidadeEmprestimosAtivos}");
            Console.WriteLine($"Resultado: {VerificarEmprestimo(aluno)}");

            Console.WriteLine();

            Console.WriteLine("PROFESSOR");
            Console.WriteLine($"Nome: {professor.Nome}");
            Console.WriteLine($"Departamento: {professor.Departamento}");
            Console.WriteLine($"Empréstimos ativos: {professor.QuantidadeEmprestimosAtivos}");
            Console.WriteLine($"Resultado: {VerificarEmprestimo(professor)}");

            Console.WriteLine();

            Console.WriteLine("VISITANTE");
            Console.WriteLine($"Nome: {visitante.Nome}");
            Console.WriteLine($"Documento: {visitante.Documento}");
            Console.WriteLine($"Resultado: {VerificarEmprestimo(visitante)}");

            // ================= TESTES =================

            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine("              TESTES DO PATTERN MATCHING");
            Console.WriteLine("==============================================");

            // Teste do padrão null.
            Console.WriteLine();
            Console.WriteLine("Teste com objeto nulo:");
            Console.WriteLine($"Resultado: {VerificarEmprestimo(null)}");

            // Teste do padrão _.
            object outroObjeto = new object();

            Console.WriteLine();
            Console.WriteLine("Teste com objeto não classificado:");
            Console.WriteLine($"Resultado: {VerificarEmprestimo(outroObjeto)}");

            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine("              FIM DO PROGRAMA");
            Console.WriteLine("==============================================");

            Console.ReadKey();
        }
    }
}