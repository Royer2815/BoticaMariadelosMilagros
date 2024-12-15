using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion
{
    public class AplicacionReporte
    {
        private List<Factura> facturas;
        private List<Cliente> clientes;

        public AplicacionReporte(List<Factura> facturas, List<Cliente> clientes)
        {
            this.facturas = facturas;
            this.clientes = clientes;
        }

        public void GenerarInformeVentas()
        {
            var totalVentas = facturas.Sum(f => f.Total);
            Console.WriteLine("Total de Ventas: $" + totalVentas);
            foreach (var factura in facturas)
            {
                var cliente = clientes.Find(c => c.IdCliente == factura.IdCliente);
                Console.WriteLine($"Factura ID: {factura.IdFactura}, Cliente: {cliente?.Nombre}, Total: {factura.Total}, Fecha: {factura.Fecha.ToShortDateString()}");
            }
        }
    }
}
