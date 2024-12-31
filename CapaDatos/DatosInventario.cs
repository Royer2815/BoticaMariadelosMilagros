using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DatosInventario
    {
        private readonly string connectionString;

        public DatosInventario(string connString)
        {
            connectionString = connString;
        }

        public void AgregarInventario(int idProducto, int cantidadDisponible, int cantidadMinima, DateTime fechaUltimaActualizacion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Inventario (IdProducto, CantidadDisponible, CantidadMinima, FechaUltimaActualizacion) VALUES (@IdProducto, @CantidadDisponible, @CantidadMinima, @FechaUltimaActualizacion)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@IdProducto", idProducto);
                command.Parameters.AddWithValue("@CantidadDisponible", cantidadDisponible);
                command.Parameters.AddWithValue("@CantidadMinima", cantidadMinima);
                command.Parameters.AddWithValue("@FechaUltimaActualizacion", fechaUltimaActualizacion);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al agregar inventario: " + ex.Message);
                }
            }
        }

        public List<Dictionary<string, object>> ObtenerInventarios()
        {
            List<Dictionary<string, object>> inventarios = new List<Dictionary<string, object>>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Inventario";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var inventario = new Dictionary<string, object>
                        {
                            { "IdInventario", reader["IdInventario"] },
                            { "IdProducto", reader["IdProducto"] },
                            { "CantidadDisponible", reader["CantidadDisponible"] },
                            { "CantidadMinima", reader["CantidadMinima"] },
                            { "FechaUltimaActualizacion", reader["FechaUltimaActualizacion"] }
                        };

                        inventarios.Add(inventario);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al obtener inventarios: " + ex.Message);
                }
            }

            return inventarios;
        }
    }
}
