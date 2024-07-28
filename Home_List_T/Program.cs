using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2:
//	Знайти в колекції типу List<string> максимальне по довжині слово, якщо таких виявляється кілька,
//    виводимо на екран те, яке стоїть раніше в словнику(алфавіті).

namespace Colection
{
    internal class Program
    {
        static string FindMaxWord(List<string> words)
        {
            if (words == null || words.Count == 0)
            {
                throw new ArgumentException("list is null.");
            }
            int maxLength = words.Max(word => word.Length);
            string firstInAlphabet = words.Where(word => word.Length == maxLength).OrderBy(word => word).First();

            return firstInAlphabet;
        }
        static void Main(string[] args)
        {
            // classwork ex 2
            //List<string> words = new List<string> { "apple", "banana", "grape", "orange", "kiwi" };

            //string maxWord = FindMaxWord(words);

            //Console.WriteLine("max word is " + maxWord);
            // classwork ex 2
            Worker worker_ = new Worker();
            Worker worker = new Worker("jack_wulskyi", "designer", "jack@123", 1002);
            Data_Base<Worker> date = new Data_Base<Worker>(new Worker(), worker_, new Worker("jack" ,"designer", "jack@123", 1002), 
                new Worker("anton", "developer", "anton@123", 3002));
            date.PrintWorkers();
            date.SearchWorkers_Pay(0);
            List<Worker> workers = date.SearchWorkers_Pay(1000);

            Console.WriteLine("******");
            foreach (var item in workers)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("******");

            date.addWorker(new Worker("olya", "maneger", "Olya@123", 3500));
            date.PrintWorkers();
            date.popWorker(worker_);
            date.PrintWorkers();
            date.editWorkers(worker, "jack");
            date.PrintWorkers();
            date.sort();
            date.PrintWorkers();
        }
    }
}
