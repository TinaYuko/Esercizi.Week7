using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
   public class Vigile
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Matricola { get; set; }
        public List<Contravvenzione> contravvenzioni { get; set; } = new List<Contravvenzione>();


        public Vigile(string nome, string cognome, int matricola)
        {
            Nome = nome;
            Cognome = cognome;
            Matricola = matricola;

        }

        public Vigile()
        {
        }
        public override string ToString()
        {
            return $"{Matricola} - Nome: {Nome} Cognome: {Cognome}";
        }
    }
}
