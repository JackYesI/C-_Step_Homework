using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Interface
{
    internal class CD :Disk, IRemoveableDisk
    {
        bool hasDisk = false;
        public CD() : base("CD", "CD memory", 300) { }
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
