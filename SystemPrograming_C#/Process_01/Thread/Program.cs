using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Thread_
{
    internal class Program
    {
        public class AlgorithmConfig
        {
            
            public AlgorithmConfig(string Name, int Count, int DelayMilliseconds)
            {
                this.Name = Name;
                this.Count = Count;
                this.DelayMilliseconds = DelayMilliseconds;
            }
            public string Name { get; set; }
            public int Count { get; set; }
            public int DelayMilliseconds { get; set; }
        }
        static void Main(string[] args)
        {
            ////CancellationTokenSource cancellationTokenSource1 = new CancellationTokenSource();
            ////CancellationTokenSource cancellationTokenSource2 = new CancellationTokenSource();
            ////CancellationTokenSource cancellationTokenSource3 = new CancellationTokenSource();
            ///

            //Thread thread1 = new Thread(() => Phibonachi(new AlgorithmConfig("Phibonachi algoritm", 20, 50), 'q'));
            //Thread thread2 = new Thread(() => MaxFactorial(new AlgorithmConfig("Factorial algoritm", 20, 50), 'w'));
            //Thread thread3 = new Thread(() => EasyNum(new AlgorithmConfig("Easy numbers algoritm", 20, 50), 'e'));

            Task thread1 = Task.Run(() => Phibonachi(new AlgorithmConfig("Phibonachi algoritm", 20, 50), 'q'));
            Task thread2 = Task.Run(() => MaxFactorial(new AlgorithmConfig("Factorial algoritm", 20, 50), 'w'));
            Task thread3 = Task.Run(() => EasyNum(new AlgorithmConfig("Easy numbers algoritm", 20, 50), 'e'));

            //thread1.Start();
            //thread2.Start();
            //thread3.Start();
            //thread1.IsBackground = true;
            //thread2.IsBackground = true;
            //thread3.IsBackground = true;

            Task.WhenAll(thread1, thread2, thread3).Wait();

            Console.WriteLine("Hello");

       

            Console.ReadKey();
        }
        public static void Phibonachi(AlgorithmConfig config, char stopKey)
        {
            Console.WriteLine($"Thread {config.Name} start");
            int a = 0, b = 1;

            Console.WriteLine(a);
            Console.WriteLine(b);

            for (int i = 0; i < config.Count; i++)
            {
                int next = a + b;
                a = b;
                b = next;
                if (next < 0 || (Console.KeyAvailable && Console.ReadKey(true).KeyChar == stopKey))
                {
                    Console.WriteLine($"Thread {config.Name} has done !!!");
                    return;
                }
                Console.WriteLine($"Next {next}");
                Thread.Sleep(config.DelayMilliseconds);
            }
            Console.WriteLine($"Thread {config.Name} has done !!!");
        }
        public static int Factorial(int num)
        {
            if (num == 1) return num;
            else return num * Factorial(num - 1);
        }
        public static void MaxFactorial(AlgorithmConfig config, char stopKey)
        {
            Console.WriteLine($"Thread {config.Name} start");
            int num_ = 2;
            while (config.Count > 0)
            {
                config.Count--;
                int P = Factorial(num_);
                if (P < 0 || (Console.KeyAvailable && Console.ReadKey(true).KeyChar == stopKey))
                {
                    Console.WriteLine($"Thread {config.Name} has done max num for int is {num_ - 1}");
                    return;
                }
                else
                {
                    num_++;
                    Console.WriteLine($"cheak number {num_ - 1} factorial is {P}");
                    Thread.Sleep(config.DelayMilliseconds);
                }
            }
            Console.WriteLine($"Thread {config.Name} has done !!!");
        }
        public static bool isEasy(int num)
        {
            for (int i = 2; i < num / 2; i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
        public static void EasyNum(AlgorithmConfig config, char stopKey)
        {
            Console.WriteLine($"Thread {config.Name} start");
            for (int i = 2; i <= config.Count; i++)
            {
                if ((Console.KeyAvailable && Console.ReadKey(true).KeyChar == stopKey))
                {
                    Console.WriteLine($"Thread {config.Name} has done !!!");
                    return;
                }
                Console.WriteLine($"number {i} is Easy ? {isEasy(i)}");
                Thread.Sleep(config.DelayMilliseconds);
            }
            Console.WriteLine($"Thread {config.Name} has done !!!");
        }
    }
}
