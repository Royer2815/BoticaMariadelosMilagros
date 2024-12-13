using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EntFactura
    {
        public int IdFactura { get; set; }                     // Identificación única de la factura  
        public int IdPedido { get; set; }                       // Identificación del pedido asociado  
        public DateTime FechaFactura { get; set; }              // Fecha en la que se generó la factura  
        public decimal Total { get; set; }                       // Total de la compra  
        public string MetodoPago { get; set; }                  // Método de pago usado (efectivo, tarjeta, etc.)  
        public List<EntProductoPedido> Productos { get; set; }  // Lista de productos facturados  

        // Constructor  
        public EntFactura()
        {
            Productos = new List<EntProductoPedido>();          // Inicialización de la lista de productos  
        }

        // Método para agregar un producto a la factura  
        public void AgregarProducto(EntProductoPedido productoPedido)
        {
            Productos.Add(productoPedido);                       // Agregar el producto a la lista  
            Total += productoPedido.CalcularTotalProducto();     // Actualiza el total de la factura  
        }

        // Método para generar un resumen de la factura  
        public string GenerarResumen()
        {
            var resumen = $"Factura ID: {IdFactura}\n" +
                           $"Fecha: {FechaFactura}\n" +
                           $"Total: {Total:C}\n" +
                           $"Método de Pago: {MetodoPago}\n" +
                           $"Productos:\n";
            foreach (var producto in Productos)
            {
                resumen += $"- {producto}\n"; // Llama al método ToString de EntProductoPedido  
            }
            return resumen;
        }
    }
}