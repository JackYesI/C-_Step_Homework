using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Home_Interface
{
    internal class Comp
    {
        int countDisc;
        int countPrintDevise;
        Disk[] disks;
        IPrintInformation[] printDevice;
        public Comp()
        {
            countDisc = 0;
            countPrintDevise = 0;
        }
        public Comp(params Disk[] disks)
        {
            countDisc = disks.Length;
            this.disks = disks;
            countPrintDevise = 0;
        }
        public void AddDevice(int index, IPrintInformation ipi)
        {
            if (printDevice == null)
            {
                printDevice = new IPrintInformation[1];
                printDevice[0] = ipi;
                ++countPrintDevise;
                return;
            }
            if (index < 0 && index > printDevice.Length)
            {
                Console.WriteLine("Error (out of range) \nfunction (AddDevice)\n");
                return;
            }
            System.Array.Resize(ref printDevice, printDevice.Length + 1);
            for (int i = printDevice.Length - 1; i >= index; i--)
            {
                if (i == index) printDevice[i] = ipi;
                else
                    printDevice[i] = printDevice[i - 1];
            }
            ++countPrintDevise;
        }
        public void AddDisk(int index, Disk disk)
        {
            if (disks == null)
            {
                disks = new Disk[1];
                disks[0] = disk;
                ++countDisc;
                return;
            }
            if (index < 0 && index > printDevice.Length)
            {
                Console.WriteLine("Error (out of range) \nfunction (AddDevice)\n");
                return;
            }
            System.Array.Resize(ref disks, disks.Length + 1);
            for (int i = disks.Length - 1; i >= index; i--)
            {
                if (i == index) disks[i] = disk;
                else
                    disks[i] = disks[i - 1];
            }
            ++countDisc;
        }
        public bool CheckDisk(string devise)
        {
            foreach (var item in disks)
            {
                if (item.getName().Equals(devise)) return ((IRemoveableDisk)item).HasDisk;
            }
            Console.WriteLine($"Do not search devise ({devise})");
            return false;
        }
        public int BinarySearch(Disk search_disk, int left, int right)
        {
            if (right > left)
            {
                return -1;
            }
            int average = (left + right) / 2;
            if (disks[average].Size > search_disk.Size)
            {
                return BinarySearch(search_disk, left, average - 1);
            }
            else if (disks[average].Size < search_disk.Size)
            {
                return BinarySearch(search_disk, average + 1, right);
            }
            else
                return average;
        }
        public void QuckSort(int left, int right)
        {
            Disk temp;
            int i = left, j = right;
            while (i <= j)
            {
                while (disks[i].Size < disks[(left + right) / 2].Size) ++i;
                while (disks[j].Size > disks[(left + right) / 2].Size) --j;

                if (i <= j)
                {
                    temp = disks[i];
                    disks[i] = disks[j];
                    disks[j] = temp;
                    ++i;
                    --j;
                }
            }
            if (j > left)
                QuckSort(left, j);
            if (i < right)
                QuckSort(i, right);
        }
        public void InsertReject(string devise, bool b)
        {
            foreach (var item in disks)
            {
                if (item.getName() == devise)
                {
                    if (b)
                    {
                        if (CheckDisk(devise) == b)
                            Console.WriteLine($"disk slot is busy\nthe disc ({item.getName()}) cannot be inserted");
                        else
                            ((IRemoveableDisk)item).Insert();
                    }
                    else
                        if (((IRemoveableDisk)item).HasDisk == b)
                        Console.WriteLine("slot is empty");
                    else
                        ((IRemoveableDisk)item).Reject();
                }
            }

        }
        public bool PrintInfo(string text, string devise)
        {
            Console.WriteLine(text + "\n");
            foreach (var item in disks)
            {
                if (item.getName() == devise)
                {
                    Console.WriteLine(ReadInfo(item.getName()) + "\n" + $"Has disk is {((IRemoveableDisk)item).HasDisk}");
                    return true;
                }
            }
            return false;
        }
        public string ReadInfo(string devise)
        {
            foreach (var item in disks)
            {
                if (item.getName() == devise)
                    return item.Read();
            }
            return "NoRead";
        }
        public void ShowDisk()
        {
            foreach (var item in disks)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public void ShowPrintDevise()
        {
            foreach (var item in printDevice)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public bool WriteInfo(string text, string showDevise)
        {
            Console.WriteLine(text + "\n");
            foreach (var item in printDevice)
            {
                if (item.GetName() == showDevise)
                {
                    ((IPrintInformation)item).Print(text);
                    return true;
                }
            }
            return false;
        }
    }
}
