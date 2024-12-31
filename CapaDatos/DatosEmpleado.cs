using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DatosEmpleado
    {
        private readonly string connectionString;

        public DatosEmpleado(string connString)
        {
            connectionString = connString;
        }

        public void AgregarEmpleado(string nombre, string apellido, string cargo, string telefono, string email, DateTime fechaContratacion, decimal salario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Empleados (Nombre, Apellido, Cargo, Telefono, Email, FechaContratacion, Salario) VALUES (@Nombre, @Apellido, @Cargo, @Telefono, @Email, @FechaContratacion, @Salario)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Apellido", apellido);
                command.Parameters.AddWithValue("@Cargo", cargo);
                command.Parameters.AddWithValue("@Telefono", telefono);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@FechaContratacion", fechaContratacion);
                command.Parameters.AddWithValue("@Salario", salario);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al agregar empleado: " + ex.Message);
                }
            }
        }

        public List<Dictionary<string, object>> ObtenerEmpleados()
        {
            List<Dictionary<string, object>> empleados = new List<Dictionary<string, object>>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Empleados";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var empleado = new Dictionary<string, object>
                        {
                            { "IdEmpleado", reader["IdEmpleado"] },
                            { "Nombre", reader["Nombre"] },
                            { "Apellido", reader["Apellido"] },
                            { "Cargo", reader["Cargo"] },
                            { "Telefono", reader["Telefono"] },
                            { "Email", reader["Email"] },
                            { "FechaContratacion", reader["FechaContratacion"] },
                            { "Salario", reader["Salario"] }
                        };

                        empleados.Add(empleado);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al obtener empleados: " + ex.Message);
                }
            }

            return empleados;
        }
    }
}