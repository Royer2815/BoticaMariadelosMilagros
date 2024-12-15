using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Producto
    {
        public int Id { get; set; } // Identificador único del producto  
        public string Nombre { get; set; } // Nombre del producto  
        public decimal Precio { get; set; } // Precio del producto  
        public int Stock { get; set; } // Cantidad disponible en stock  
    }
}
