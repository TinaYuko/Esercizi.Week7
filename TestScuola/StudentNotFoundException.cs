using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScuola
{
    public class StudentNotFoundException : Exception 
    {
        public string Nome { get; }
        public string Cognome { get; }

        public StudentNotFoundException() 
        { }

        public StudentNotFoundException(string message)
            : base(message) 
        { }

        public StudentNotFoundException(string message, Exception inner)
            : base(message, inner) 
        { }
    }
}
