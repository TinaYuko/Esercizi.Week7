using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
    public class Menu
    {
        private static DBContravvenzioni dbContravvenzioni = new DBContravvenzioni();
        private static DBVigile dbVigile = new DBVigile();
        internal static void Start()
        {
            /* Visualizza contravvenzioni
               Visualizza contravvenzioni di un determinato vigile -> tramite id
               Visualizza contravvenzione di un determinato veicolo -> tramite accesso 
            Accesso tramite DB
             */
            
           
            Console.WriteLine("Benvenut* al Menù principale della Stazione della Polizia Municipale di Quartu Sant'Elena.");
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("Si prega di premere: ");
                Console.WriteLine("[1] Per poter visionare le contravvenzioni effettuate");
                Console.WriteLine("[2] Per visionare le contravvenzioni effettuate da un determinato vigile");
                Console.WriteLine("[3] Per visionare le contravvenzioni effettuate ad un determinato veicolo");
                Console.WriteLine("[0] Per uscire");


                int scelta = Scegli();
                //do
                //{
                //    Console.WriteLine("Si prega di scegliere");
                //} while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta < 5));

                switch (scelta)
                {
                    case 1:
                        VisualizzaContravvenzioni();
                        break;
                    case 2:
                        VisualizzaPerVigile();
                        break;
                    case 3:
                        VisualizzaPerVeicolo();
                        break;
                    case 0:
                        Console.WriteLine("La ringraziamo per aver visionato il nostro portale. Arrivederci!");
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta errata");
                        break;
                }
            }
        }

        private static int Scegli()
        {
            try
            {
                Console.Write("Scegli: ");
                int scelta = int.Parse(Console.ReadLine());
                return scelta;
            }
            catch
            {
                Console.WriteLine("Errore!!");
                return -1;
            }
        }

        private static void VisualizzaPerVeicolo()
        {
            
            Console.Write("Inserisci la targa del vigile: ");
            string targa = Console.ReadLine();
            List<Contravvenzione> contravvenzioni = dbContravvenzioni.GetContravvenzioniByTarga(targa);
            Console.WriteLine("Le contravvenzioni effettuate al veicolo, sono: ");
            foreach (var item in contravvenzioni)
            {
                Console.WriteLine(item.ToString());
            }

        }

        private static void VisualizzaPerVigile()
        {
            VisualizzaVigili();
            int matricola;
            Console.Write("Inserisci la matricola del vigile: ");
            while (!(int.TryParse(Console.ReadLine(), out matricola) && matricola > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            List<Contravvenzione> contravvenzioni = dbContravvenzioni.GetContravvenzioniByMatricola(matricola);
            Console.WriteLine("Le contravvenzioni effettuate dal vigile selezionato, sono: ");
            foreach (var item in contravvenzioni)
            {
                Console.WriteLine(item.ToString());
            }


        }

        private static void VisualizzaContravvenzioni()
        {
            Console.WriteLine("Tutti le contravvenzioni sono: ");
            List<Contravvenzione> contravvenzioni= dbContravvenzioni.GetAll();
            foreach (var item in contravvenzioni)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void VisualizzaVigili()
        {
            Console.WriteLine("Tutti i vigili della Stazione sono: ");
            List<Vigile> vigili = dbVigile.GetAll();
            foreach (var item in vigili)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
