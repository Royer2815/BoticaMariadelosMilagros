using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entProveedor
    {
        public int IdProveedor { get; set; }              // Identificación única del proveedor  
        public string Nombre { get; set; }                 // Nombre del proveedor  
        public string Direccion { get; set; }              // Dirección del proveedor  
        public string Telefono { get; set; }                // Teléfono de contacto  
        public string Email { get; set; }                  // Correo electrónico de contacto  

        // Constructor por defecto  
        public entProveedor() { }

        // Método para mostrar información del proveedor  
        public override string ToString()
        {
            return $"ID: {IdProveedor}, Nombre: {Nombre}, Dirección: {Direccion}, " +
                   $"Teléfono: {Telefono}, Email: {Email}";
        }
    }
}