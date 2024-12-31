using System;
using System.Collections.Generic;



namespace CapaAplicacion
{
    public class AplicacionPago
    {
        private List<Pago> pagos = new List<Pago>();

        public void AgregarPago(int idFactura, decimal monto, DateTime fecha, string metodo)
        {
            var pago = new Pago
            {
                IdPago = pagos.Count + 1,
                IdFactura = idFactura,
                Monto = monto,
                Fecha = fecha,
                Metodo = metodo
            };

            pagos.Add(pago);
            Console.WriteLine("Pago agregado: " + pago.IdPago);
        }

        public IEnumerable<Pago> ObtenerPagos()
        {
            return pagos;
        }
    }

    public class Pago
    {
        public int IdPago { get; set; }
        public int IdFactura { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Metodo { get; set; }
    }
}