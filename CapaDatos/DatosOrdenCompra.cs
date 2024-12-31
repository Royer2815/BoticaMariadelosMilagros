using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DatosOrdenCompra
    {
        private readonly string connectionString;

        public DatosOrdenCompra(string connString)
        {
            connectionString = connString;
        }

        public void AgregarOrdenCompra(int idProveedor, DateTime fechaOrden, decimal total, string estado)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO OrdenCompra (IdProveedor, FechaOrden, Total, Estado) VALUES (@IdProveedor, @FechaOrden, @Total, @Estado)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@IdProveedor", idProveedor);
                command.Parameters.AddWithValue("@FechaOrden", fechaOrden);
                command.Parameters.AddWithValue("@Total", total);
                command.Parameters.AddWithValue("@Estado", estado);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al agregar orden de compra: " + ex.Message);
                }
            }
        }

        public List<Dictionary<string, object>> ObtenerOrdenesCompra()
        {
            List<Dictionary<string, object>> ordenesCompra = new List<Dictionary<string, object>>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM OrdenCompra";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var ordenCompra = new Dictionary<string, object>
                        {
                            { "IdOrdenCompra", reader["IdOrdenCompra"] },
                            { "IdProveedor", reader["IdProveedor"] },
                            { "FechaOrden", reader["FechaOrden"] },
                            { "Total", reader["Total"] },
                            { "Estado", reader["Estado"] }
                        };

                        ordenesCompra.Add(ordenCompra);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al obtener las órdenes de compra: " + ex.Message);
                }
            }

            return ordenesCompra;
        }
    }
}