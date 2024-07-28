using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Comp comp = new Comp(new CD(), new DVD(), new Flash(), new HDD());
            comp.AddDevice(0, new Monitor());
            comp.AddDevice(1, new Printer());
            Console.WriteLine(comp.ReadInfo("CD") + "\n");

            Console.WriteLine();

            comp.PrintInfo("info CD", "CD");
            comp.InsertReject("CD", true);
            comp.PrintInfo("info CD", "CD");

            comp.PrintInfo("info CD", "CD");
            comp.InsertReject("CD", true);
            comp.PrintInfo("info CD", "CD");

            comp.PrintInfo("info CD", "CD");
            comp.InsertReject("CD", false);
            comp.PrintInfo("info CD", "CD");

            Console.WriteLine();
            comp.ShowDisk();
            Console.WriteLine();
            comp.ShowPrintDevise();

            if (comp.WriteInfo("text text text text", "Monitor")) Console.WriteLine("Operation success");
            else
                Console.WriteLine("Operation failed");
            if (comp.WriteInfo("text text text text", "Printer")) Console.WriteLine("Operation success");
            else
                Console.WriteLine("Operation failed");
        }
    }
}
