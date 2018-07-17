using DiaCotizacion;
using FileManager;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation
{
    public class Quotation
    {
        OpenFile _openFile = new OpenFile();
        readonly string path = "stocks-ITX.csv";
        List<Cotizacion> listColumns = new List<Cotizacion>();
        List<Cotizacion> ListaInversion;
        Decimal resultado = 0;

        public Quotation() {
        }

        public List<Cotizacion>GetColumns() {

            string line;
            StreamReader sr = _openFile.OpenCSV(path);

            while ((line = sr.ReadLine()) != null) {
                string [] row = line.Split(';');

                if (!row[0].Equals("Fecha")) {
                    DateTime Fecha = DateTime.ParseExact(row[0], "dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("es-US"));
                    Decimal cierre = Convert.ToDecimal(row[1].Replace('.', ','));
                    Decimal apertura = Convert.ToDecimal(row[2].Replace('.', ','));
                    listColumns.Add(new Cotizacion(Fecha, apertura, cierre));
                }
            }

            //Obtengo la lista de la Fecha, apertura y cierre. 
            return listColumns;

        }

        public DateTime LastThurstDay(DateTime date)
        {
            var lastDayOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

            while (lastDayOfMonth.DayOfWeek != DayOfWeek.Thursday)
                lastDayOfMonth = lastDayOfMonth.AddDays(-1);
            return lastDayOfMonth;
        }


        public void CheckDateBuy() {
            
            List<DateTime> LisDates = new List<DateTime>();
            decimal acciones = 0;
            decimal totalAcciones = 0;
            decimal suma = 0;
            DateTime DiaInvertido;
            int mesActual = 0;

            foreach (Cotizacion cp in listColumns)
                {
                    LisDates.Add(cp.Fecha);   
                }
 
            foreach (DateTime dt in LisDates)
            {
                if (mesActual != dt.Month)
                {
                    mesActual = dt.Month;
                    DiaInvertido = LastThurstDay(dt).AddDays(1);
                    Console.WriteLine("Invierto el dia: " + DiaInvertido);
                    listColumns.Reverse();

                    foreach (Cotizacion ct in listColumns)
                    {
                        if (ct.Fecha == DiaInvertido)
                        {
                            ListaInversion = new List<Cotizacion>
                            {
                                new Cotizacion(ct.Fecha, ct.Apertura, ct.Cierre)
                            };

                            Console.WriteLine("Fecha: " + ct.Fecha + " Apertura: " +ct.Apertura);
  
                            acciones = 49 / ct.Apertura;
                            totalAcciones = Math.Round(acciones, 3);
                            Console.WriteLine("Total Acciones: " + totalAcciones);
                            
                            suma = suma + totalAcciones;
                            Console.WriteLine("Suma :" + suma);
                            resultado = suma * Convert.ToDecimal(29.17);
                            Console.WriteLine("Resultado total: " + resultado);
                        }
                    }

                    
                }
                
            }

            Console.ReadKey();
        }
    }
}
