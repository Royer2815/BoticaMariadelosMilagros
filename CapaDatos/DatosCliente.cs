using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatosCliente
    {
        private readonly string connectionString;

        public DatosCliente(string connString)
        {
            connectionString = connString;
        }

        public void AgregarCliente(string nombre, string apellido, string telefono, string email, string direccion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Clientes (Nombre, Apellido, Telefono, Email, Direccion) VALUES (@Nombre, @Apellido, @Telefono, @Email, @Direccion)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Apellido", apellido);
                command.Parameters.AddWithValue("@Telefono", telefono);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Direccion", direccion);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al agregar cliente: " + ex.Message);
                }
            }
        }

        public List<Dictionary<string, object>> ObtenerClientes()
        {
            List<Dictionary<string, object>> clientes = new List<Dictionary<string, object>>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Clientes";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var cliente = new Dictionary<string, object>
                        {
                            { "IdCliente", reader["IdCliente"] },
                            { "Nombre", reader["Nombre"] },
                            { "Apellido", reader["Apellido"] },
                            { "Telefono", reader["Telefono"] },
                            { "Email", reader["Email"] },
                            { "Direccion", reader["Direccion"] }
                        };

                        clientes.Add(cliente);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al obtener clientes: " + ex.Message);
                }
            }

            return clientes;
        }
    }
}