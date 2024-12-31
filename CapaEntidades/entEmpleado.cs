using System;






namespace CapaEntidades
{
    public class EntEmpleado
    {
        public int IdEmpleado { get; set; }                // Identificación única del empleado  
        public string Nombre { get; set; }                  // Nombre del empleado  
        public string Apellido { get; set; }                // Apellido del empleado  
        public string Cargo { get; set; }                   // Cargo del empleado  
        public string Telefono { get; set; }                // Teléfono de contacto  
        public string Email { get; set; }                   // Email del empleado  
        public DateTime FechaContratacion { get; set; }    // Fecha de contratación  
        public decimal Salario { get; set; }                // Salario del empleado  

        // Constructor por defecto  
        public EntEmpleado() { }

        // Método para mostrar información del empleado  
        public override string ToString()
        {
            return $"ID Empleado: {IdEmpleado}, Nombre: {Nombre} {Apellido}, " +
                   $"Cargo: {Cargo}, Teléfono: {Telefono}, Email: {Email}, " +
                   $"Fecha de Contratación: {FechaContratacion.ToShortDateString()}, " +
                   $"Salario: {Salario:C}";
        }
    }
}
