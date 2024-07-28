using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_Interfaces
{
    internal class Comp
    {
        int countDisc;
        int countPrintDevise;
        Disk[] disks;
        IPrintInformation[] printDevice;
        public Comp()
        {
            countDisc= 0;
            countPrintDevise= 0;
        }
        void AddDevice(int index, IPrintInformation ipi)
        {
            // add last realization
            IPrintInformation[] newDisks = new IPrintInformation[++countPrintDevise];
            for (int i = 0; i < countPrintDevise; i++)
            {
                newDisks[i] = printDevice[i];
            }
            newDisks[countPrintDevise - 1] = ipi;
            printDevice = newDisks;
        }
    }
}
