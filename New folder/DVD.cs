using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_Interfaces
{
    internal class DVD:Disk, IRemoveableDisk
    {
        bool hasDisk = false;
        public bool HasDisk { get { return hasDisk; } }

        public override string getName()
        {
            return base.ToString() + this.ToString();
        }
        public void Insert()
        {
            this.hasDisk = true;
        }

        public void Reject()
        {
            this.hasDisk = false;
        }
    }
}
