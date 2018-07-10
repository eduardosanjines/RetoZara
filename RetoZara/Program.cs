using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoZara
{
    class Program
    {

        static void Main(string[] args)

        {
            int i = 0;
            string line;
            Char colum = ';';
            Char punto = '.';
            Char coma = ',';
            String[] row;
            decimal convertTodecimal = 0;
            decimal resultado = 0;
            decimal round = 0;
            decimal roundPercent = 0;
            decimal resultado_total = 0;
            decimal porcentaje = 0;
            string reempl;

            StreamReader file = new StreamReader(@"stocks-ITX.csv");

            while ((line = file.ReadLine()) != null)
            {
                //parseo por columna delimitando por ";"
                row = line.Split(colum);
                //obtengo el resultado de todas las columnas (Cierre)
                resultado = resultado + round;
                porcentaje = resultado *2 / 100;
                roundPercent = Math.Round(porcentaje, 3);
                resultado_total = resultado - roundPercent;
                i++;

                if (!row[0].Equals("Fecha") || !row[1].Equals("Cierre") || !row[2].Equals("Apertura"))
                {
                    if (row[1].Contains("."))
                    {
                       //reemplazo el punto por la coma
                       reempl = row[1].Replace(punto, coma);
                       convertTodecimal = Convert.ToDecimal(reempl);
                       round=  Math.Round(convertTodecimal, 3);
                    }
                }
            }
            //cierro fichero
            file.Close();
            Console.WriteLine("\nResultado sin restarle el tanto por ciento: "+resultado);
            Console.WriteLine("\nPorcentaje del 2% redondeado: " + roundPercent);
            Console.WriteLine("\nResultado total: "+resultado_total);
            //muestro por consola el resultado
            Console.ReadKey();
        }  
    }
}
