using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Interface
{
    internal interface IPrintInformation
    {
        string GetName();
        void Print(string str);
    }
}
