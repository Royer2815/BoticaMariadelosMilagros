using System;
using System.Collections.Generic;

namespace CapaAplicacion
{
    public class AplicacionFactura
    {
        private List<Factura> facturas = new List<Factura>();

        public void AgregarFactura(int idCliente, decimal total, DateTime fecha, string estado)
        {
            var factura = new Factura
            {
                IdFactura = facturas.Count + 1,
                IdCliente = idCliente,
                Total = total,
                Fecha = fecha,
                Estado = estado
            };

            facturas.Add(factura);
            Console.WriteLine("Factura agregada: " + factura.IdFactura);
        }

        public IEnumerable<Factura> ObtenerFacturas()
        {
            return facturas;
        }
    }

    public class Factura
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}