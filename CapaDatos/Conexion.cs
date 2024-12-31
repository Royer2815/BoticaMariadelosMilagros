using System;
using System.Data.SqlClient;

class Conexion
{
    static void Main()
    {
        
        string connectionString = @"Server=localhost\DESKTOP-E720FUG\SQLEXPRESS;Database=DB_botica_milagros;Integrated Security=True";

        
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // Abrir la conexión
                connection.Open();

                
                SqlCommand command = new SqlCommand("SELECT * from Empleado", connection);
                SqlDataReader reader = command.ExecuteReader();
                //probando un comentario en c# y subiendo al repositorio github
                while (reader.Read())
                {
                    Console.WriteLine(reader[0].ToString()); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
