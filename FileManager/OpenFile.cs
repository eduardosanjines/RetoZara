using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class OpenFile
    {
        public StreamReader OpenCSV(string path) {

            StreamReader sr = new StreamReader(path);
           
            return sr;
        }
    }
}
