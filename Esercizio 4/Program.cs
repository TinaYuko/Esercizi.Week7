using System;
using System.Collections.Generic;
using System.IO;

namespace Esercizio_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Carica Dati da File");
            string path = @"C:\Users\RenataCarriero\source\repos\Week7_PreAcademyD\CaricaDatiDaFile\DatiDaCaricare.txt";

            StreamReader sr = null;

            try
            {
                //Lettura di tutto il file e divisione del file in righe
                using (sr = new StreamReader(path))
                {
                    string contenutoFile = sr.ReadToEnd();
                    var righeDelMioFile = contenutoFile.Split("\r\n");

                    List<int> datiDelFile = new List<int>();
                    for (int i = 0; i < (righeDelMioFile.Length); i++)
                    {
                        string rigaIesima = righeDelMioFile[i];
                        datiDelFile.Add(int.Parse(rigaIesima));
                    }

                    Console.WriteLine("Sono stati caricati i seguenti dati");
                    foreach (var item in datiDelFile)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File non trovato");
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore di formato. Controlla i dati del file");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore Generico");
                Console.WriteLine(ex);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }
    }
}
