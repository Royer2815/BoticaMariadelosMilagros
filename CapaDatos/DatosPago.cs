using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatosPago
    {
        private readonly string connectionString;

        public DatosPago(string connString)
        {
            connectionString = connString;
        }

        public void AgregarPago(int idFactura, decimal monto, DateTime fecha, string metodo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Pagos (IdFactura, Monto, Fecha, Metodo) VALUES (@IdFactura, @Monto, @Fecha, @Metodo)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@IdFactura", idFactura);
                command.Parameters.AddWithValue("@Monto", monto);
                command.Parameters.AddWithValue("@Fecha", fecha);
                command.Parameters.AddWithValue("@Metodo", metodo);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al agregar pago: " + ex.Message);
                }
            }
        }

        public List<Dictionary<string, object>> ObtenerPagos()
        {
            List<Dictionary<string, object>> pagos = new List<Dictionary<string, object>>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Pagos";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var pago = new Dictionary<string, object>
                        {
                            { "IdPago", reader["IdPago"] },
                            { "IdFactura", reader["IdFactura"] },
                            { "Monto", reader["Monto"] },
                            { "Fecha", reader["Fecha"] },
                            { "Metodo", reader["Metodo"] }
                        };

                        pagos.Add(pago);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al obtener pagos: " + ex.Message);
                }
            }

            return pagos;
        }
    }
}