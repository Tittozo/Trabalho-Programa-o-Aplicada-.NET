using System;
using System.Collections.Generic;
using System.Text;

namespace PatternMatching
{
    // Classe base que representa um usuário da biblioteca.
    public class UsuarioBiblioteca
    {
        // Nome do usuário.
        public string Nome { get; set; }

        // Quantidade de empréstimos que o usuário possui atualmente.
        public int QuantidadeEmprestimosAtivos { get; set; }
    }
}