using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EntPedido
    {
        public int IdPedido { get; set; }                     // Identificación única del pedido  
        public int IdUsuario { get; set; }                     // Identificación del usuario que realiza el pedido  
        public DateTime FechaPedido { get; set; }              // Fecha en que se realizó el pedido  
        public List<EntProductoPedido> Productos { get; set; } // Lista de productos en el pedido  
        public decimal Total { get; private set; }             // Total del pedido (calculado)  
        public string Estado { get; set; }                      // Estado del pedido (ej: "Pendiente", "Completado", "Cancelado")  

        // Constructor  
        public EntPedido()
        {
            Productos = new List<EntProductoPedido>();         // Inicialización de la lista de productos  
            Estado = "Pendiente";                              // Estado inicial por defecto  
        }

        // Método para calcular el total del pedido  
        public void CalcularTotal()
        {
            Total = 0; // Reinicia el total  
            foreach (var producto in Productos)
            {
                Total += producto.Precio * producto.Cantidad; // Suma el precio total de los productos  
            }
        }

        // Método para agregar un producto al pedido  
        public void AgregarProducto(int idProducto, decimal precio, int cantidad)
        {
            var productoPedido = new EntProductoPedido
            {
                IdProducto = idProducto,
                Precio = precio,
                Cantidad = cantidad
            };
            Productos.Add(productoPedido);
            CalcularTotal(); // Actualiza el total al agregar un producto  
        }

        // Método para cambiar el estado del pedido  
        public void CambiarEstado(string nuevoEstado)
        {
            Estado = nuevoEstado; // Asigna el nuevo estado  
        }
    }

    // Clase auxiliar para representar un producto en un pedido  
    public class EntProductoPedido
    {
        public int IdProducto { get; set; }    // Identificación del producto  
        public int Cantidad { get; set; }      // Cantidad del producto en el pedido  
        public decimal Precio { get; set; }     // Precio del producto al momento del pedido  
    }
}