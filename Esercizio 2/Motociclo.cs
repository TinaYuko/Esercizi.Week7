using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
    class Motociclo : Veicolo
    {
        public string NumTelaio { get; set; }

        public Motociclo(string targa, string numTelaio) : base (targa)
        {
            NumTelaio = numTelaio;
        }
    }
}
