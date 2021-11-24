using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScuola
{
    public class DBManager
    {
        string connectionStringFalza = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NomeACaso;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Scuola;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Valutazione> GetAll()
        {
            SqlConnection connection = null;

            try
            {
                using (connection = new SqlConnection(connectionStringFalza))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from Valutazioni";

                    SqlDataReader reader = command.ExecuteReader();

                    List<Valutazione> valutazioni = new List<Valutazione>();

                    while (reader.Read())
                    {
                        string materia = (string)reader["Materia"];
                        int voto = (int)reader["Voto"];
                        DateTime data = (DateTime)reader["Data"];
                        int idStudente = (int)reader["Studente"];

                        Studente s = new Studente();
                        s.IdStudente = (int)idStudente;


                        Valutazione v = new Valutazione(materia, voto, data, (Studente)s);
                        valutazioni.Add(v);
                    }
                    return valutazioni;
                }
            }
            catch (SqlException sqlE)
            {
                Console.WriteLine("Ooops, qualcosa è andato storto!");
                Console.WriteLine($"Errore: {sqlE.Message}");
                return new List<Valutazione>();
            }
            catch (NullReferenceException nullE)
            {
                Console.WriteLine("Ooops, qualcosa è andato genericamente storto!");
                Console.WriteLine($"Errore: {nullE.Message}");
                return new List<Valutazione>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ooops, qualcosa è andato ANCORA PIU' GENERICAMENTE storto!");
                Console.WriteLine($"Errore: {e.Message}");
                return new List<Valutazione>();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        internal Studente GetStudentById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from Studente where IdStudente= @id";
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    Studente s = new Studente();
                    while (reader.Read())
                    {
                        var id2 = reader["IdStudente"];
                        var nome = reader["Nome"];
                        var cognome = reader["Cognome"];
                        var dataNascita = reader["DataNascita"];

                        s.IdStudente = (int)id;
                        s.Nome = (string)nome;
                        s.Cognome = (string)cognome;
                        s.DataNascita = (DateTime)dataNascita;
                    }
                    connection.Close();
                    return s;       
            }
        }
    }
}
