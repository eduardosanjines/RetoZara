using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaCotizacion
{
    public class Cotizacion
    {
        public DateTime Fecha { get; set; }
        public decimal Apertura { get; set; }
        public decimal Cierre { get; set; }

        public Cotizacion(DateTime date, decimal cierre, decimal apertura)
        {
            Fecha = date;
            Apertura = apertura;
            Cierre = cierre;
        }

        public Cotizacion(DateTime date, decimal apertura)
        {
            Fecha = date;
            Apertura = apertura;
        }



    }
}
