using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EntInventario
    {
        public int IdInventario { get; set; }               // Identificación única del inventario  
        public int IdProducto { get; set; }                  // Identificación del producto  
        public int CantidadDisponible { get; set; }          // Cantidad actualmente disponible  
        public int CantidadMinima { get; set; }              // Cantidad mínima para disparar una alerta  
        public DateTime FechaUltimaActualizacion { get; set; } // Fecha de la última actualización del inventario  

        // Constructor por defecto  
        public EntInventario() { }

        // Método para mostrar información del inventario  
        public override string ToString()
        {
            return $"ID Inventario: {IdInventario}, Producto ID: {IdProducto}, " +
                   $"Cantidad Disponible: {CantidadDisponible}, " +
                   $"Cantidad Mínima: {CantidadMinima}, " +
                   $"Última Actualización: {FechaUltimaActualizacion.ToShortDateString()}";
        }
    }
}