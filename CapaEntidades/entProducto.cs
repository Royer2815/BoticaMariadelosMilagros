using System;
using System.Collections.Generic;





namespace CapaEntidades
{
    public class EntProducto
    {
        public int IdProducto { get; set; }               // Identificación del producto  
        public string Nombre { get; set; }                 // Nombre del producto  
        public string Descripcion { get; set; }            // Descripción del producto  
        public decimal Precio { get; set; }                // Precio del producto  
        public decimal Descuento { get; set; }             // Descuento en porcentaje  
        public bool Estado { get; set; }                    // Estado del producto (activo/inactivo)  
        public int Stock { get; set; }                      // Cantidad disponible en inventario  
        public string Categoria { get; set; }               // Categoría del producto  
        public DateTime FechaCreacion { get; set; }        // Fecha de creación del producto  
        public string Proveedor { get; set; }               // Proveedor del producto  
        public string ImagenUrl { get; set; }               // URL de la imagen del producto  
        public DateTime? FechaExpiracion { get; set; }     // Fecha de expiración (opcional)  
        public string SKU { get; set; }                     // Código de unidad de mantenimiento de stock (SKU)  
        public List<Resena> Reseñas { get; set; }          // Reseñas de clientes  

        // Propiedad calculada para el precio final  
        public decimal PrecioFinal => Precio * (1 - Descuento / 100);

        // Constructor  
        public EntProducto()
        {
            Reseñas = new List<Resena>();
        }

        // Método para mostrar información del producto  
        public override string ToString()
        {
            return $"ID: {IdProducto}, Nombre: {Nombre}, Precio: {Precio:C}, Descuento: {Descuento}%, " +
                   $"Precio Final: {PrecioFinal:C}, Estado: {(Estado ? "Activo" : "Inactivo")}, " +
                   $"Stock: {Stock}, Categoría: {Categoria}, Fecha de Creación: {FechaCreacion.ToShortDateString()}, " +
                   $"Proveedor: {Proveedor}, SKU: {SKU}, Imagen: {ImagenUrl}";
        }

        // Método para cambiar el estado del producto  
        public void CambiarEstado()
        {
            Estado = !Estado; // Alterna el estado  
        }

        // Método para ajustar el stock  
        public void AjustarStock(int cantidad)
        {
            Stock += cantidad; // Aumenta o disminuye el stock  
        }
    }

    public class Resena
    {
        public string Cliente { get; set; }            // Nombre del cliente que hace la reseña  
        public int Calificacion { get; set; }          // Calificación del producto (ej. 1 a 5)  
        public string Comentario { get; set; }         // Comentario del cliente  

        public override string ToString()
        {
            return $"{Cliente} dio una calificación de {Calificacion}: {Comentario}";
        }
    }
}