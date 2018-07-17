using FileManager;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoZara
{
    public class Program
    {

        static void Main(string[] args)

        {
            Quotation.Quotation q = new Quotation.Quotation();
            q.GetColumns();
            q.CheckDateBuy();
        }
    }
}
