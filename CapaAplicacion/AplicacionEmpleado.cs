using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion
{
    public class AplicacionEmpleado
    {
        private List<Empleado> empleados = new List<Empleado>(); // Lista en memoria para simular la capa de datos  

        public void AgregarEmpleado(string nombre, string apellido, string cargo, string telefono, string email, DateTime fechaContratacion, decimal salario)
        {
            var empleado = new Empleado
            {
                IdEmpleado = empleados.Count + 1, // Simulación de ID  
                Nombre = nombre,
                Apellido = apellido,
                Cargo = cargo,
                Telefono = telefono,
                Email = email,
                FechaContratacion = fechaContratacion,
                Salario = salario
            };

            empleados.Add(empleado);
            Console.WriteLine("Empleado agregado: " + empleado.Nombre + " " + empleado.Apellido);
        }

        public IEnumerable<Empleado> ObtenerEmpleados()
        {
            return empleados;
        }
    }

    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaContratacion { get; set; }
        public decimal Salario { get; set; }
    }
}