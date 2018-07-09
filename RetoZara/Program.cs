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
            Char delimitador = ';';
            String[] row;
            String fecha, cierre, apertura;
            float fcierre;

            StreamReader file = new StreamReader(@"stocks-ITX.csv");

            while ((line = file.ReadLine()) != null)
            {
                row = line.Split(delimitador);
                i++;

                fecha = row[0];
                cierre = row[1];
                apertura = row[2];
                if (!row[0].Equals("Fecha") || !row[1].Equals("Cierre") || !row[2].Equals("Apertura"))
                {
                    fcierre = Convert.ToSingle(cierre);
                  //  Console.WriteLine(fcierre);
                    Console.WriteLine(Math.Round(fcierre, 2));
                }
            }
         
           
          
            
            /*
            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();
            */
        }
    }
}
