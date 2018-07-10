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
            decimal d = 0;
            decimal resultado = 0;
            decimal redondeado = 0;
            decimal resultado_total = 0;
            decimal porcentaje = 0;
            string reempl;

            StreamReader file = new StreamReader(@"stocks-ITX.csv");

            while ((line = file.ReadLine()) != null)
            {
                //parseo por columna delimitando por ";"
                row = line.Split(colum);
                //obtengo el % y le sumo al resultado
                resultado = resultado + redondeado;
                porcentaje = resultado *2 / 100;
                resultado_total = resultado - porcentaje;
                i++;

                if (!row[0].Equals("Fecha") || !row[1].Equals("Cierre") || !row[2].Equals("Apertura"))
                {
                    if (row[1].Contains("."))
                    {
                            //reemplazo el punto por la coma
                       reempl = row[1].Replace(punto, coma);
                       d = Convert.ToDecimal(reempl);
                       redondeado=  Math.Round(d);
                    }
                }
            }
            //cierro fichero
            file.Close();
            Console.WriteLine(resultado_total);
            Console.ReadKey();
        }  
    }
}
