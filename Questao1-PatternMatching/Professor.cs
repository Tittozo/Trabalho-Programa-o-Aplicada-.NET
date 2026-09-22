using PatternMatching;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatternMatching
{
    // Professor também herda da classe UsuarioBiblioteca.
    public class Professor : UsuarioBiblioteca
    {
        // Departamento ao qual o professor pertence.
        public string Departamento { get; set; }
    }
}
