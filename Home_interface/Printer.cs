using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Interface
{
    internal class Printer : IPrintInformation
    {
        public string GetName()
        {
            return "Printer";
        }

        public void Print(string str)
        {
            Console.WriteLine($"Printer works :: \n \t {str}");
        }
    }
}
