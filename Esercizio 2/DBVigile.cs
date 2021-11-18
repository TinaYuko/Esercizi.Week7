using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
    public class DBVigile : IManager<Vigile>
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Municipale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Vigile> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Vigile";

                SqlDataReader reader = command.ExecuteReader();

                List<Vigile> vigili= new List<Vigile>();

                while (reader.Read())
                {
                    int matricola = (int)reader["Matricola"];
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];

                    Vigile v = new Vigile(nome, cognome, matricola);
                    vigili.Add(v);
                }
                connection.Close();
                return vigili;
            }
        }

        public Vigile GetByVeicolo(string targa)
        {
            throw new NotImplementedException();
        }

        public Vigile GetByVigile(int matricola)
        {
            throw new NotImplementedException();
        }

    }
}
