using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
    public class Contravvenzione
    {
        private int numero;
        private int matricola;
        private string targa;

        public int NumVerbale { get; set; }
        public string Luogo { get; set; }
        public DateTime Data { get; set; }
        public Vigile Vigile { get; set; }
        public Veicolo Veicolo { get; set; }




        public Contravvenzione(int numVerbale, string luogo, DateTime data, Vigile vigile, Veicolo veicolo)
        {
            NumVerbale = numVerbale;
            Luogo = luogo;
            Data = data;
            Vigile = vigile;
            Veicolo = veicolo;
        }

        public Contravvenzione(int numero, string luogo, DateTime data, int matricola, string targa)
        {
            this.numero = numero;
            Luogo = luogo;
            Data = data;
            Vigile.Matricola = matricola;
            Veicolo.Targa = targa;
        }

        public override string ToString()
        {
            return $"Verbale NUMERO: {NumVerbale} - effettuato in Data: {Data.ToShortDateString()} a {Luogo} dal Vigile: {Vigile.Matricola} al veicolo di TARGA: {Veicolo.Targa}";
        }
    }
}
