using System;
using System.Collections.Generic;


namespace CapaAplicacion
{
    public class AplicacionProducto
    {
        private List<Producto> productos = new List<Producto>();

        public void AgregarProducto(string nombre, string descripcion, decimal precio, int stock)
        {
            var producto = new Producto
            {
                IdProducto = productos.Count + 1,
                Nombre = nombre,
                Descripcion = descripcion,
                Precio = precio,
                Stock = stock
            };

            productos.Add(producto);
            Console.WriteLine("Producto agregado: " + producto.Nombre);
        }

        public IEnumerable<Producto> ObtenerProductos()
        {
            return productos;
        }

        public Producto BuscarProducto(int idProducto)
        {
            return productos.Find(p => p.IdProducto == idProducto);
        }
    }

    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}