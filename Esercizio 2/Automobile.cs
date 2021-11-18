using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
    public class Automobile : Veicolo
    {
        public double Potenza { get; set; }

        public Automobile(string targa, double potenza): base (targa)
        {
            Potenza = potenza;
        }
    }
}
