using System;






namespace CapaEntidades
{
    public class EntConsulta
    {
        public int IdConsulta { get; set; }                // Identificación única de la consulta  
        public int IdCliente { get; set; }                  // Identificación del cliente que realizó la consulta  
        public string Pregunta { get; set; }                 // Pregunta realizada por el cliente  
        public string Respuesta { get; set; }                // Respuesta dada a la consulta  
        public DateTime FechaConsulta { get; set; }         // Fecha en que se realizó la consulta  
        public bool EstaRespondida { get; set; }            // Indica si la consulta ha sido respondida  

        // Constructor por defecto  
        public EntConsulta() { }

        // Método para mostrar información de la consulta  
        public override string ToString()
        {
            return $"ID Consulta: {IdConsulta}, Cliente ID: {IdCliente}, " +
                   $"Pregunta: {Pregunta}, Respuesta: {Respuesta}, " +
                   $"Fecha: {FechaConsulta.ToShortDateString()}, " +
                   $"¿Respondida?: {EstaRespondida}";
        }
    }
}