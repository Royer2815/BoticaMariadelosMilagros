using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DatosProducto
    {
        private readonly string connectionString;

        public DatosProducto(string connString)
        {
            connectionString = connString;
        }

        // Método para agregar un nuevo producto  
        public void AgregarProducto(string nombre, string descripcion, decimal precio, int stock)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Productos (Nombre, Descripcion, Precio, Stock) VALUES (@Nombre, @Descripcion, @Precio, @Stock)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Descripcion", descripcion);
                command.Parameters.AddWithValue("@Precio", precio);
                command.Parameters.AddWithValue("@Stock", stock);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al agregar producto: " + ex.Message);
                }
            }
        }

        // Método para obtener todos los productos  
        public List<Dictionary<string, object>> ObtenerProductos()
        {
            List<Dictionary<string, object>> productos = new List<Dictionary<string, object>>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Productos";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var producto = new Dictionary<string, object>
                        {
                            { "IdProducto", reader["IdProducto"] },
                            { "Nombre", reader["Nombre"] },
                            { "Descripcion", reader["Descripcion"] },
                            { "Precio", reader["Precio"] },
                            { "Stock", reader["Stock"] }
                        };

                        productos.Add(producto);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al obtener productos: " + ex.Message);
                }
            }

            return productos;
        }

        // Método para actualizar un producto existente  
        public void ActualizarProducto(int idProducto, string nombre, string descripcion, decimal precio, int stock)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Productos SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, Stock = @Stock WHERE IdProducto = @IdProducto";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@IdProducto", idProducto);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Descripcion", descripcion);
                command.Parameters.AddWithValue("@Precio", precio);
                command.Parameters.AddWithValue("@Stock", stock);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al actualizar producto: " + ex.Message);
                }
            }
        }

        // Método para eliminar un producto  
        public void EliminarProducto(int idProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Productos WHERE IdProducto = @IdProducto";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@IdProducto", idProducto);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al eliminar producto: " + ex.Message);
                }
            }
        }
    }
}