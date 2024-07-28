using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_Interfaces
{
    interface IDisk
    {
        string Read();
        void Write(string text);
    }
}
