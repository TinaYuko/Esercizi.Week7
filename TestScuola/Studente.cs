using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScuola
{
    public class Studente
    {
        public int IdStudente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public List<Valutazione> Valutazioni { get; set; } = new List<Valutazione>();


        public Studente CheckStudent(int id) 
        {
            //Mi creo un caso per generare per forza l'eccezione
            Studente s = new Studente();
            if (id==9765468)
            {
                return s;
            }
            else 
            {
                throw new StudentNotFoundException("Non esiste uno studente con questo ID");
            }
        }
    }
}

