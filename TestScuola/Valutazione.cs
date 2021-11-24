using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScuola
{
    public class Valutazione
    {
        private Studente s;

        public Valutazione(string materia, int voto, DateTime data, Studente s)
        {
            Materia = materia;
            Voto = voto;
            Data = data;
            this.s = s;
        }

        public string Materia { get; set; }
        public int Voto { get; set; }
        public DateTime Data { get; set; }
        public Studente Studente { get; set; }

        public override string ToString()
        {
            return $"Valutazione effettuata in data {Data} - Materia: {Materia}, Voto: {Voto}, Studente: {Studente.IdStudente}";
        }
    }
}
