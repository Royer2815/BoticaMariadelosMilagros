using System;
using System.Collections.Generic;






namespace CapaEntidades
{
    public class EntOrdenCompra
    {
        public int IdOrdenCompra { get; set; }                 // Identificación única de la orden de compra  
        public int IdProveedor { get; set; }                    // Identificación del proveedor  
        public DateTime FechaOrden { get; set; }                // Fecha en que se realizó la orden  
        public decimal Total { get; set; }                      // Total de la orden de compra  
        public string Estado { get; set; }                      // Estado de la orden (por ejemplo, "Pendiente", "Completada")  
        public List<EntProductoPedido> ListaProductos { get; set; } // Lista de productos incluidos en la orden  

        // Constructor por defecto  
        public EntOrdenCompra()
        {
            ListaProductos = new List<EntProductoPedido>(); // Inicializa la lista de productos  
        }

        // Método para calcular el total de la orden de compra  
        public void CalcularTotal()
        {
            Total = 0;
            foreach (var producto in ListaProductos)
            {
                Total += producto.Precio * producto.Cantidad; // Asumiendo que EntProductoPedido tiene propiedades Precio y Cantidad  
            }
        }

        // Método para mostrar información de la orden de compra  
        public override string ToString()
        {
            return $"Orden de Compra ID: {IdOrdenCompra}, Proveedor ID: {IdProveedor}, " +
                   $"Fecha: {FechaOrden.ToShortDateString()}, Total: {Total:C}, Estado: {Estado}";
        }
    }
}
