﻿




namespace CapaEntidades
{
    public class CapaEntidades
    {
        public int IdProducto { get; set; }      // Identificación del producto  
        public int Cantidad { get; set; }        // Cantidad del producto en el pedido  
        public decimal Precio { get; set; }      // Precio del producto al momento del pedido  

        // Constructor opcional  

        // Método para calcular el total de este producto en el pedido  
        public decimal CalcularTotalProducto()
        {
            return Precio * Cantidad;             // Calcula el total por este producto  
        }

        public override string ToString()
        {
            return $"Producto ID: {IdProducto}, Cantidad: {Cantidad}, Precio: {Precio:C}, Total: {CalcularTotalProducto():C}";
        }
    }
}