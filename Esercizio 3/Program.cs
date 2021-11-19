using System;

namespace Esercizio_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var nc = new NumeroComplesso();

            Console.WriteLine("Divisione tra numeri complessi");
            Console.Write("Inserisci parte reale del primo numero complesso: ");
            double.TryParse(Console.ReadLine(),out double a);
            Console.Write("Inserisci parte immaginaria del primo numero complesso: ");
            double.TryParse(Console.ReadLine(), out double b);
            Console.Write("Inserisci parte reale del secondo numero complesso: ");
            double.TryParse(Console.ReadLine(), out double c);
            Console.Write("Inserisci parte immaginaria del secondo numero complesso: ");
            double.TryParse(Console.ReadLine(), out double d);

            NumeroComplesso primo = new NumeroComplesso { ParteReale = a, ParteImmaginaria = b };
            NumeroComplesso secondo = new NumeroComplesso { ParteReale = c, ParteImmaginaria = d };
            try
            {
                NumeroComplesso risultato = primo.Divisione(secondo);
                Console.WriteLine(risultato);
            }
            catch (NumeroComplessoException nCE)
            {
                Console.WriteLine($"{nCE.Message}");
                Console.WriteLine($"Dividendo: {nCE.PrimoOperatore} - Divisore: {nCE.SecondoOperatore}");
            }
        }
    }
}
