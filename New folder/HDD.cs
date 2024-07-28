using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_Interfaces
{
    internal class HDD : Disk
    {
        public override string getName()
        {
            return base.getName() + this.ToString();
        }
    }
}
