using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFecha
{
    class Program
    {
        static void Main(string[] args)
        {

            //Primero obtenemos el día actual
            DateTime date = DateTime.Now;
            //Asi obtenemos el primer dia del mes actual
           // DateTime oPrimerDiaDelMes = new DateTime(date.Year, date.Month, 3);

            //Y de la siguiente forma obtenemos el ultimo dia del mes
            //agregamos 1 mes al objeto anterior y restamos 1 día.
           // DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);
            date.AddYears(2001);
            int anyo = date.Year;
            int mes = date.Month;
           // int dias = DateTime.DaysInMonth(date.AddYears(2001), DateTime.Now.Month);

         //   Console.WriteLine("\n1 del mes: "+oPrimerDiaDelMes);
            Console.WriteLine("\naño: " + date.AddYears(2001));

        //    Console.WriteLine("2 del mes: "+ oUltimoDiaDelMes);
            Console.ReadKey();
            

        }
    }
}
