using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatosConsulta
    {
        private readonly string connectionString;

        public DatosConsulta(string connString)
        {
            connectionString = connString;
        }

        public void AgregarConsulta(int idCliente, string pregunta, string respuesta, DateTime fechaConsulta, bool estaRespondida)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Consultas (IdCliente, Pregunta, Respuesta, FechaConsulta, EstaRespondida) VALUES (@IdCliente, @Pregunta, @Respuesta, @FechaConsulta, @EstaRespondida)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@IdCliente", idCliente);
                command.Parameters.AddWithValue("@Pregunta", pregunta);
                command.Parameters.AddWithValue("@Respuesta", respuesta);
                command.Parameters.AddWithValue("@FechaConsulta", fechaConsulta);
                command.Parameters.AddWithValue("@EstaRespondida", estaRespondida);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al agregar consulta: " + ex.Message);
                }
            }
        }

        public List<Dictionary<string, object>> ObtenerConsultas()
        {
            List<Dictionary<string, object>> consultas = new List<Dictionary<string, object>>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Consultas";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var consulta = new Dictionary<string, object>
                        {
                            { "IdConsulta", reader["IdConsulta"] },
                            { "IdCliente", reader["IdCliente"] },
                            { "Pregunta", reader["Pregunta"] },
                            { "Respuesta", reader["Respuesta"] },
                            { "FechaConsulta", reader["FechaConsulta"] },
                            { "EstaRespondida", reader["EstaRespondida"] }
                        };

                        consultas.Add(consulta);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al obtener consultas: " + ex.Message);
                }
            }

            return consultas;
        }
    }
}