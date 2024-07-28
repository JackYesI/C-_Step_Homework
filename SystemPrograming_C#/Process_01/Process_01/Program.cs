using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Threading;


namespace Process_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Process process = Process.GetCurrentProcess();
            //Process[] processes = Process.GetProcesses();
            //foreach (var item in processes)
            //{
            //    Console.WriteLine($"Process name {item.ProcessName}");
            //}


            //Process.Start("calc.exe");
            ////Console.ReadLine();
            //Process.Start("notepad.exe");
            ////Console.ReadLine();
            //Process.Start("Paint.exe");

            //Console.ReadLine();

            // All Processes
            Console.WriteLine("Choose 1) 2 sec;\t 2) 5 sec;\t 3) 10 sec;\t 4) Arm");
            string str = Console.ReadLine();
            int num = 0;
            bool flag = false;
            try
            {
                num = Int32.Parse(str);
            }
            catch 
            {
                Console.WriteLine("Not int");
                Console.ReadKey();
                Process.GetCurrentProcess().Kill();
            }

            if (num == 1) num = 2000;
            if (num == 2) num = 5000;
            if (num == 3) num = 10000;
            if (num == 4) flag = true;
            while (true)
            {
                int num_1 = 0;
                ShowAllProcess();
                if (!flag)
                {
                    Thread.Sleep(num);
                }
                else
                {
                    Console.WriteLine("1) Ever move -> refresh;\t 2) 2 -> Show info for Id;\t 3) \"Kill\" -> stop process;\t 4) \"path\" -> start process");
                    string str_1 = Console.ReadLine();
                    if (str_1 == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("Enter Id of process");
                        str_1 = Console.ReadLine();
                        try
                        {
                            num_1 = Int32.Parse(str_1);
                        }
                        catch
                        {
                            Console.WriteLine("Not int");
                            Console.ReadKey();
                            Process.GetCurrentProcess().Kill();
                        }
                        ShowInfo(num_1);
                    }
                    if (str_1 == "Kill")
                    {
                        Console.Clear();
                        Console.WriteLine("Enter Id of process");
                        str_1 = Console.ReadLine();
                        try
                        {
                            num_1 = Int32.Parse(str_1);
                        }
                        catch
                        {
                            Console.WriteLine("Not int");
                            Console.ReadKey();
                            Process.GetCurrentProcess().Kill();
                        }
                        Process.GetProcessById(num_1).CloseMainWindow();
                    }
                    if (str_1 == "path")
                    {
                        Console.Clear();
                        Console.WriteLine("Enter path to .exe of process");
                        str_1 = Console.ReadLine();
                        str_1.Replace("\\", "\\\\");
                        Process.Start(str_1);
                    }
                }
            }


        }
        public static void ShowInfo(int Id)
        {
            Process pr = Process.GetProcessById(Id);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"ProcessName\t\t Id \t PriorityClass \t StartTime \t ProcessorAffinity \t Container \t MachineName \t PagedMemorySize64");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            try
            {
                Console.WriteLine($"{pr.ProcessName,-20} {pr.Id,-5} {pr.PriorityClass,-10} {pr.StartTime, -10} {pr.ProcessorAffinity, -5} {pr.Container,-5} {pr.MachineName,-5} {pr.PagedMemorySize64}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error with {pr.ProcessName}");
                Console.ResetColor();
            }
            Console.ResetColor();
            Console.ReadLine();
        }
        public static void ShowAllProcess()
        {
            Console.Clear();
            Process[] processes = Process.GetProcesses();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"ProcessName\t\t Id \t PriorityClass \t StartTime");
            Console.ResetColor();
            foreach (var p in processes)
            {
                try
                {
                    Console.WriteLine($"{p.ProcessName,-20} {p.Id,-5} {p.PriorityClass,-10} {p.StartTime}");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error with {p.ProcessName}");
                    Console.ResetColor();
                }
            }
        }
    }
}
