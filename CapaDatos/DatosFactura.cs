using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DatosFactura
    {
        private readonly string connectionString;

        public DatosFactura(string connString)
        {
            connectionString = connString;
        }

        public void AgregarFactura(int idCliente, decimal total, DateTime fecha, string estado)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Facturas (IdCliente, Total, Fecha, Estado) VALUES (@IdCliente, @Total, @Fecha, @Estado)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@IdCliente", idCliente);
                command.Parameters.AddWithValue("@Total", total);
                command.Parameters.AddWithValue("@Fecha", fecha);
                command.Parameters.AddWithValue("@Estado", estado);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al agregar factura: " + ex.Message);
                }
            }
        }

        public List<Dictionary<string, object>> ObtenerFacturas()
        {
            List<Dictionary<string, object>> facturas = new List<Dictionary<string, object>>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Facturas";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var factura = new Dictionary<string, object>
                        {
                            { "IdFactura", reader["IdFactura"] },
                            { "IdCliente", reader["IdCliente"] },
                            { "Total", reader["Total"] },
                            { "Fecha", reader["Fecha"] },
                            { "Estado", reader["Estado"] }
                        };

                        facturas.Add(factura);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al obtener facturas: " + ex.Message);
                }
            }

            return facturas;
        }
    }
}