using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Interface
{
    internal interface IRemoveableDisk
    {
        bool HasDisk { get; set; }
        void Insert();
        void Reject();
    }
}
