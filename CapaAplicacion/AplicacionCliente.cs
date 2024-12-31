using System;
using System.Collections.Generic;


namespace CapaAplicacion
{
    public class AplicacionCliente
    {
        private List<Cliente> clientes = new List<Cliente>();

        public void AgregarCliente(string nombre, string apellido, string telefono, string email, string direccion)
        {
            var cliente = new Cliente
            {
                IdCliente = clientes.Count + 1,
                Nombre = nombre,
                Apellido = apellido,
                Telefono = telefono,
                Email = email,
                Direccion = direccion
            };

            clientes.Add(cliente);
            Console.WriteLine("Cliente agregado: " + cliente.Nombre + " " + cliente.Apellido);
        }

        public IEnumerable<Cliente> ObtenerClientes()
        {
            return clientes;
        }
    }

    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
