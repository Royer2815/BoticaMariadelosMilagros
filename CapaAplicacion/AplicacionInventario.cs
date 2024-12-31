using System;
using System.Collections.Generic;

namespace CapaAplicacion
{
    public class AplicacionInventario
    {
        private List<Producto> productos;

        public AplicacionInventario(List<Producto> productos)
        {
            this.productos = productos;
        }

        public void AumentarStock(int idProducto, int cantidad)
        {
            var producto = productos.Find(p => p.IdProducto == idProducto);
            if (producto != null)
            {
                producto.Stock += cantidad;
                Console.WriteLine("Stock aumentado: " + producto.Nombre + " ahora tiene " + producto.Stock + " unidades.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void ReducirStock(int idProducto, int cantidad)
        {
            var producto = productos.Find(p => p.IdProducto == idProducto);
            if (producto != null)
            {
                if (producto.Stock >= cantidad)
                {
                    producto.Stock -= cantidad;
                    Console.WriteLine("Stock reducido: " + producto.Nombre + " ahora tiene " + producto.Stock + " unidades.");
                }
                else
                {
                    Console.WriteLine("No hay suficiente stock para reducir.");
                }
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }
    }
}