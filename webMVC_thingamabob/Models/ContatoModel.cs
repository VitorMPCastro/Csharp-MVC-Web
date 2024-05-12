using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Data.SqlClient;

namespace webMVC_thingamabob.Models
{
    public class ContatoModel : IDisposable
    {
        private SqlConnection connection;

        public ContatoModel()
        {
            string strConn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDContato;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

			connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Contato contato)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO Contato (Nome, Email) VALUES (@Nome, @Email)";
            cmd.Parameters.AddWithValue("@Nome", contato.Nome);
            cmd.Parameters.AddWithValue("@Email", contato.Email);
            cmd.ExecuteNonQuery();
        }

        public List<Contato> Read()
        {
            List<Contato> lista = new List<Contato>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM Contato";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Contato contato = new Contato();
                contato.IdContato = (int)reader["IdContato"];
                contato.Nome = (string)reader["Nome"];
                contato.Email = (string)reader["Email"];
                lista.Add(contato);
            }

            return lista;
        }

        public void Update(Contato contato)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "UPDATE Contato SET Nome = @Nome, Email = @Email WHERE IdContato = @IdContato";
            cmd.Parameters.AddWithValue("@IdContato", contato.IdContato);
            cmd.Parameters.AddWithValue("@Nome", contato.Nome);
            cmd.Parameters.AddWithValue("@Email", contato.Email);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "DELETE FROM Contato WHERE IdContato = @IdContato";
            cmd.Parameters.AddWithValue("@IdContato", id);
            cmd.ExecuteNonQuery();
        }
    }
}
