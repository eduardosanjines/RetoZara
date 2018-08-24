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
        
        List<Cotizacion> listBuy = new List<Cotizacion>();
        List<Cotizacion> ListaInversion;
        Decimal resultado = 0;

        public Quotation() {
        }

        public List<Cotizacion> GetColumns() {

            string path = "stocks-ITX.csv";
            string line;

            StreamReader sr = _openFile.OpenCSV(path);

            while ((line = sr.ReadLine()) != null) {

                string [] row = line.Split(';');

                if (!row[0].Equals("Fecha")) {

                    DateTime Fecha = DateTime.ParseExact(row[0], "dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("es-US"));
                    Decimal cierre = Convert.ToDecimal(row[1].Replace('.', ','));
                    Decimal apertura = Convert.ToDecimal(row[2].Replace('.', ','));

                    listBuy.Add(new Cotizacion(Fecha, apertura));

                }
            }

            //Obtengo la lista de la Fecha y apertura. 
            return listBuy;

        }

        /// <summary>
        /// Metodo que retorna el último jueves de cada mes. 
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Ultimo Jueves de cada mes</returns>
        public DateTime UltimoJuevesDelMes(DateTime date)
        {
            var lastDayOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

            ////DayOfWeek = Sunday (El ultimo día del mes fue Sunday para el 2017)
            while (lastDayOfMonth.DayOfWeek != DayOfWeek.Thursday)
                lastDayOfMonth = lastDayOfMonth.AddDays(-1);

            return lastDayOfMonth;

        }


        public void FechaDeCompra() {
            
            List<DateTime> LisDates = new List<DateTime>();
            decimal acciones = 0;
            decimal totalAcciones = 0;
            decimal suma = 0;
            DateTime DiaInvertido;
            int mesActual = 0;


            foreach (Cotizacion cp in listBuy)
                {
                    //Agregamos a la lista todas las fechas del excel
                    LisDates.Add(cp.Fecha);

                }
 
            foreach (DateTime dt in LisDates)
            {
                if (mesActual != dt.Month)
                {
                    mesActual = dt.Month;

                    //Obtenemos el día invertido
                    DiaInvertido = UltimoJuevesDelMes(dt).AddDays(1);
                   // DiaInvertido = UltimoDiaDelMes(dt);

                    foreach (Cotizacion ct in listBuy)
                        {

                            //Si la fecha que está en el excel (lista) es igual al dia invertido
                            if (ct.Fecha == DiaInvertido)
                            {
                                ListaInversion = new List<Cotizacion>
                            {
                                new Cotizacion(ct.Fecha, ct.Apertura)
                            };

                            if(ct.Fecha == DiaInvertido)
                            {
                                if(ct.Fecha.DayOfWeek == DayOfWeek.Thursday)
                                {
                                    ListaInversion = new List<Cotizacion>
                                }
                            }

                                acciones = 49 / ct.Apertura;
                                totalAcciones = Math.Round(acciones, 3);

                                Console.WriteLine("Fecha: " + ct.Fecha + " Apertura: " + ct.Apertura + " " + " Total Acciones: " + totalAcciones);

                                suma = suma + totalAcciones;
                                resultado = suma * Convert.ToDecimal(29.170);
                                
                            }
                        }

                    
                }
                
            }
            Console.WriteLine("Suma :" + suma);
            Console.WriteLine("Resultado total: " + resultado);
            Console.ReadKey();
        }
    }
}
