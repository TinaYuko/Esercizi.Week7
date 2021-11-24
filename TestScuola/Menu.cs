using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScuola
{
    class Menu
    {
        private static DBManager dbManager = new DBManager();

        internal static void Start()
        {
            Console.WriteLine("Benvenut* al registro elettronico dell'Industriale I.I.S. Primo Levi.");
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("Si prega di premere: ");
                Console.WriteLine("[1] Per visionare le valutazioni presenti. ");
                Console.WriteLine("[2] Per aggiungere una valutazione. ");
                Console.WriteLine("[0] Per uscire");


                int scelta;
                do
                {
                    Console.WriteLine("Si prega di scegliere");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta < 5));

                switch (scelta)
                {
                    case 1:
                        VisualizzaValutazioni();
                        break;
                    case 2:
                        AddValutazione();
                        break;
                    case 0:
                        Console.WriteLine("La ringraziamo per aver visionato il nostro portale. Arrivederci!");
                        continua = false;
                        break;
                }
            }
        }

        private static void AddValutazione()
        {
            try
            {
                Studente s = new Studente();
                int id;
                Console.Write("Inserire l'Id Studente: ");
                while (!(int.TryParse(Console.ReadLine(), out id) && id > 0))
                {
                    Console.WriteLine("Valore errato. Riprova:");
                }

                //s = dbManager.GetStudentById(id);
                s.CheckStudent(id); //Verificarsi dell'eccezione

                //E poi segue altro codice per aggiungere la valutazione al registro
            }
            catch (StudentNotFoundException studentException)
            {
                Console.WriteLine("Abbiamo riscontrato un'errore!");
                Console.WriteLine($"{studentException.Message}");
            }
        }

    

        private static void VisualizzaValutazioni()
        {
            Console.WriteLine("Tutte le valutazioni presenti, sono: ");
            List<Valutazione> valutazioni = dbManager.GetAll();
            foreach (var item in valutazioni)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
