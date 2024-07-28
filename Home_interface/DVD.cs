using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Interface
{
    internal class DVD : Disk, IRemoveableDisk
    {
        bool hasDisk = false;
        public DVD() : base("DVD", "DVD Memory", 400) { }
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
