using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
    public class DBContravvenzioni : IManager<Contravvenzione>
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Municipale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
       
        public List<Contravvenzione> GetAll()
        {
            SqlConnection connection = null;

            try 
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from Contravvenzioni";

                    SqlDataReader reader = command.ExecuteReader();

                    List<Contravvenzione> contravvenzioni = new List<Contravvenzione>();

                    while (reader.Read())
                    {
                        int numero = (int)reader["NumVerbale"];
                        string luogo = (string)reader["Luogo"];
                        int matricola = (int)reader["Matricola"];
                        string targa = (string)reader["Targa"];
                        DateTime data = (DateTime)reader["Data"];

                        Vigile v = new Vigile();
                        v.Matricola = (int)matricola;
                        Veicolo veicolo = new Veicolo();
                        veicolo.Targa = (string)targa;

                        Contravvenzione c = new Contravvenzione(numero, luogo, data, (Vigile)v, (Veicolo)veicolo);
                        contravvenzioni.Add(c);
                    }
                    return contravvenzioni;
                }
            }
            catch (SqlException sqlE)
            {
               Console.WriteLine($"{sqlE.Message}");
               return new List<Contravvenzione>();
            }

            finally 
            {
                if (connection!=null)
                {
                    connection.Close();
                }
            }
        }

        internal List<Contravvenzione> GetContravvenzioniByTarga(string targaToCheck)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Contravvenzioni where Targa=@t";
                command.Parameters.AddWithValue("@t", targaToCheck);
                SqlDataReader reader = command.ExecuteReader();

                List<Contravvenzione> contravvenzioni = new List<Contravvenzione>();

                while (reader.Read())
                {
                    int numero = (int)reader["NumVerbale"];
                    string luogo = (string)reader["Luogo"];
                    int matricola = (int)reader["Matricola"];
                    string targa = (string)reader["Targa"];
                    DateTime data = (DateTime)reader["Data"];

                    Vigile v = new Vigile();
                    v.Matricola = (int)matricola;
                    Veicolo veicolo = new Veicolo();
                    veicolo.Targa = (string)targa;

                    Contravvenzione c = new Contravvenzione(numero, luogo, data, (Vigile)v, (Veicolo)veicolo);
                    contravvenzioni.Add(c);
                }
                connection.Close();
                return contravvenzioni;
            }
        }

        internal List<Contravvenzione> GetContravvenzioniByMatricola(int matricolaToCheck)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Contravvenzioni where Matricola=@m";
                command.Parameters.AddWithValue("@m", matricolaToCheck);
                SqlDataReader reader = command.ExecuteReader();

                List<Contravvenzione> contravvenzioni = new List<Contravvenzione>();

                while (reader.Read())
                {
                    int numero = (int)reader["NumVerbale"];
                    string luogo = (string)reader["Luogo"];
                    int matricola = (int)reader["Matricola"];
                    string targa = (string)reader["Targa"];
                    DateTime data = (DateTime)reader["Data"];

                    Vigile v = new Vigile();
                    v.Matricola = (int)matricola;
                    Veicolo veicolo = new Veicolo();
                    veicolo.Targa = (string)targa;

                    Contravvenzione c = new Contravvenzione(numero, luogo, data, (Vigile)v, (Veicolo)veicolo);
                    contravvenzioni.Add(c);
                }
                connection.Close();
                return contravvenzioni;
            }
        }

        
    }
}
