using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion
{
    public class AplicacionProveedor
    {
        private List<Proveedor> proveedores = new List<Proveedor>();

        public void AgregarProveedor(string nombre, string telefono, string email, string direccion)
        {
            var proveedor = new Proveedor
            {
                IdProveedor = proveedores.Count + 1,
                Nombre = nombre,
                Telefono = telefono,
                Email = email,
                Direccion = direccion
            };

            proveedores.Add(proveedor);
            Console.WriteLine("Proveedor agregado: " + proveedor.Nombre);
        }

        public IEnumerable<Proveedor> ObtenerProveedores()
        {
            return proveedores;
        }
    }

    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
