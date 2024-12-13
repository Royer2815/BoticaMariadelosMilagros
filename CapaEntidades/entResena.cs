using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EntResena
    {
        public int IdResena { get; set; }                 // Identificación única de la reseña  
        public int IdProducto { get; set; }                // Identificación del producto asociado  
        public int IdUsuario { get; set; }                 // Identificación del usuario que realiza la reseña  
        public string Comentario { get; set; }             // Texto de la reseña  
        public int Calificacion { get; set; }              // Calificación del producto (por ejemplo, de 1 a 5)  
        public DateTime Fecha { get; set; }                // Fecha en que se realizó la reseña  

        // Constructor por defecto  
        public EntResena() { }

        // Método para mostrar información de la reseña  
        public override string ToString()
        {
            return $"Reseña ID: {IdResena}, Producto ID: {IdProducto}, Usuario ID: {IdUsuario}, " +
                   $"Calificación: {Calificacion}/5, Fecha: {Fecha.ToShortDateString()}, Comentario: {Comentario}";
        }
    }
}