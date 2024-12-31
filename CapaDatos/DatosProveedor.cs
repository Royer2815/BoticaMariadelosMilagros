using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DatosProveedor
    {
        private readonly string connectionString;

        public DatosProveedor(string connString)
        {
            connectionString = connString;
        }

        public void AgregarProveedor(string nombre, string telefono, string email, string direccion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Proveedores (Nombre, Telefono, Email, Direccion) VALUES (@Nombre, @Telefono, @Email, @Direccion)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Nombre", nombre);
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
                    Console.WriteLine("Error al agregar proveedor: " + ex.Message);
                }
            }
        }

        public List<Dictionary<string, object>> ObtenerProveedores()
        {
            List<Dictionary<string, object>> proveedores = new List<Dictionary<string, object>>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Proveedores";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var proveedor = new Dictionary<string, object>
                        {
                            { "IdProveedor", reader["IdProveedor"] },
                            { "Nombre", reader["Nombre"] },
                            { "Telefono", reader["Telefono"] },
                            { "Email", reader["Email"] },
                            { "Direccion", reader["Direccion"] }
                        };

                        proveedores.Add(proveedor);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al obtener proveedores: " + ex.Message);
                }
            }

            return proveedores;
        }
    }
}