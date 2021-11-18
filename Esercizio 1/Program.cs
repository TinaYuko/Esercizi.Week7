using System;

namespace Esercizio_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];

            try
            {
                Console.Write("Immettere un numero: ");
                int n = int.Parse(Console.ReadLine());
                Console.Write($"In quale posizione vuoi assegnare il numero {n}? ");
                int posizione = int.Parse(Console.ReadLine());

                array[posizione] = n;

                Console.WriteLine("L'array sarà: ");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array[i]);
                }
            }
            catch (FormatException eccezione)
            {
                Console.WriteLine($"Errore: {eccezione.Message}");
            }
            catch (IndexOutOfRangeException eccezione)
            {
                Console.WriteLine($"Errore: {eccezione.Message}");
            }
            catch (Exception eccezioneGenerica)
            {
                Console.WriteLine($"Errore generico: {eccezioneGenerica.Message}");
            }
            finally
            {
                Console.WriteLine("Non è stato possibile mettere il numero nella posizione scelta");
            }
        }
    }
}
