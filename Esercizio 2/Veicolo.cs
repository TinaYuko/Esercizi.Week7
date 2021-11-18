using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
    public class Veicolo
    {
        public string Targa { get; set; }
        public List<Contravvenzione> contravvenzioni { get; set; } = new List<Contravvenzione>();

        public Veicolo(string targa)
        {
            Targa = targa;
        }

        public Veicolo()
        {
        }
    }
}
