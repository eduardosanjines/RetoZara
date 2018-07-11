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
            String[] row;
            decimal resultado = 0;
            decimal round = 0;

            StreamReader file = new StreamReader(@"stocks-ITX.csv");

            while ((line = file.ReadLine()) != null)
            {
                //parseo por columna delimitando por ";"
                row = line.Split(';');
                i++;

                if (!row[0].Equals("Fecha") || !row[1].Equals("Cierre") || !row[2].Equals("Apertura"))
                {
                    if (row[1].Contains("."))
                    {
                       //reemplazo el punto por la coma
                       string reempl = row[1].Replace('.', ',');
                        //Convierto a Decimal
                       decimal convertTodecimal = Convert.ToDecimal(reempl);
                        //Calculo cuantas acciones puede comprar
                       decimal acciones = 49 / convertTodecimal;
                        //redondeo el resultado de las acciones
                       round = Math.Round(acciones, 3);
                    }
                }
                
                resultado = resultado + round;

            }
            //cierro fichero
            file.Close();
            Console.WriteLine("\nResultado: "+resultado);
            Console.ReadKey();
        }  
    }
}
