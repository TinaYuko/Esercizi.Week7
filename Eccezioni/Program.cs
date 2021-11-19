using System;
using System.IO;

namespace Eccezioni
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = 8;
                int b = 0;
                int c = a / b;
                Console.WriteLine($"Il risultato della divisione è: {c}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Non puoi dividere per zero, scemo!!");
                Console.WriteLine(e.ToString());
            }
            catch (ArithmeticException eccezioneAritmetica)
            {
                Console.WriteLine("Errore matematico!!");
                Console.WriteLine(eccezioneAritmetica.ToString());
            }
            catch (Exception eccezione)
            {
                Console.WriteLine("Errore!!");
                Console.WriteLine(eccezione.ToString());
            }
            finally
            {
                Console.WriteLine("Ciao"); //se voglio che comunque venga eseguito dopo l'errore qualcosa
            }

            LeggiFile();
            Metodo1();
        }

        private static void LeggiFile()
        {
            StreamReader sr = null; 
            try
            {
                sr = new StreamReader(@"C:\Users\Marti\Desktop\Pink Academy\Week7\Eccezioni\Eccezioni/FileDaLeggere.tx");
                string contenutoFile = sr.ReadToEnd();
                Console.WriteLine(contenutoFile);
            }
            catch (FileNotFoundException eFile)
            {
                Console.WriteLine($"Errore: {eFile.Message}");

            }
            catch //mettere sempre anche quella generica
            (Exception eccezione)
            {
                Console.WriteLine($"Errore: {eccezione.Message}");
            }
            finally
            {
                if (sr!=null)
                {
                    sr.Close();
                }
            }

            

        }

        private static void Metodo1()
        {
            Console.WriteLine("Metodo1");
            ChiediNumeri();
        }

        private static void ChiediNumeri()
        {
            try
            {
                Console.Write("Inserisci primo numero: ");
                int n1 = int.Parse(Console.ReadLine());
                Console.Write("Inserisci secondo numero: ");
                int n2 = int.Parse(Console.ReadLine());

                int risultato = DividiNumeri(n1, n2);
                Console.WriteLine($"Il risultato della divisione è {risultato}");
            }
            catch(Exception eccezione)
            {
                Console.WriteLine($"Errore: {eccezione.ToString()}");
            }
        }

        private static int DividiNumeri(int n1, int n2)
        {
            return n1 / n2;
        }
    }
}
