﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_Interfaces
{
    internal class Monitor : IPrintInformation
    {
        public string GetName()
        {
            return "Monitor";
        }

        public void Print(string str)
        {
            Console.WriteLine($"Monitor works :: \n \t {str}");
        }
    }
}