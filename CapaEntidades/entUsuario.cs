using System;



namespace CapaEntidades
{
    public class EntUsuario
    {
        public int IdUsuario { get; set; }                // Identificación del usuario  
        public string Nombre { get; set; }                 // Nombre del usuario  
        public string Apellido { get; set; }               // Apellido del usuario  
        public string Email { get; set; }                  // Correo electrónico  
        public string Telefono { get; set; }               // Número de teléfono  
        public string Direccion { get; set; }              // Dirección del usuario  
        public string Contrasena { get; set; }             // Contraseña del usuario (almacenada de forma segura)  
        public bool EsAdmin { get; set; }                  // Indica si el usuario es administrador  
        public DateTime FechaRegistro { get; set; }        // Fecha en que se registró el usuario  
        public bool Estado { get; set; }                   // Estado del usuario (activo/inactivo)  

        // Método para mostrar información del usuario  
        public override string ToString()
        {
            return $"ID: {IdUsuario}, Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}, " +
                   $"Teléfono: {Telefono}, Dirección: {Direccion}, " +
                   $"Administrador: {(EsAdmin ? "Sí" : "No")}, Estado: {(Estado ? "Activo" : "Inactivo")}, " +
                   $"Fecha de Registro: {FechaRegistro.ToShortDateString()}";
        }

        // Método para cambiar el estado del usuario  
        public void CambiarEstado()
        {
            Estado = !Estado; // Alterna el estado  
        }

        // Método para verificar la contraseña (puedes agregar lógica para una comparación segura)  
        public bool VerificarContrasena(string contrasena)
        {
            return Contrasena.Equals(contrasena); // En la práctica, debes implementar un hashing seguro  
        }
    }
}
