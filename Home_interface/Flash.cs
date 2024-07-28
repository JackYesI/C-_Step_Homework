using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Interface
{
    internal class Flash :Disk, IRemoveableDisk
    {
        bool hasDisk = false;
        public Flash():base("Flash", "Flash memory", 600) { }
        public bool HasDisk { get { return hasDisk; } set { hasDisk = value; } }
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
