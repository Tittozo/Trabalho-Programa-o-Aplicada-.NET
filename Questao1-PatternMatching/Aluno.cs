using PatternMatching;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatternMatching
{
    // Aluno herda as propriedades da classe UsuarioBiblioteca.
    public class Aluno : UsuarioBiblioteca
    {
        // Matrícula específica do aluno.
        public string Matricula { get; set; }
    }
}