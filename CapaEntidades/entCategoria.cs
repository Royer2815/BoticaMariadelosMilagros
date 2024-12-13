using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EntCategoria
    {
        public int IdCategoria { get; set; }              // Identificación única de la categoría  
        public string Nombre { get; set; }                 // Nombre de la categoría  
        public string Descripcion { get; set; }            // Descripción de la categoría  

        // Constructor por defecto  
        public EntCategoria() { }

        // Método para mostrar información de la categoría  
        public override string ToString()
        {
            return $"ID: {IdCategoria}, Nombre: {Nombre}, Descripción: {Descripcion}";
        }
    }
}