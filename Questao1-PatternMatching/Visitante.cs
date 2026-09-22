using PatternMatching;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatternMatching
{
    // Visitante também herda da classe UsuarioBiblioteca.
    public class Visitante : UsuarioBiblioteca
    {
        // Documento de identificação do visitante.
        public string Documento { get; set; }
    }
}