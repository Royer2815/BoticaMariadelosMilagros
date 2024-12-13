using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EntCliente
    {
        public int IdCliente { get; set; }                  // Identificación única del cliente  
        public string Nombre { get; set; }                   // Nombre del cliente  
        public string Direccion { get; set; }                // Dirección del cliente  
        public string Telefono { get; set; }                 // Teléfono de contacto  
        public string Email { get; set; }                    // Correo electrónico  

        // Constructor por defecto  
        public EntCliente() { }

        // Método para mostrar información del cliente  
        public override string ToString()
        {
            return $"ID: {IdCliente}, Nombre: {Nombre}, Dirección: {Direccion}, " +
                   $"Teléfono: {Telefono}, Email: {Email}";
        }
    }
}