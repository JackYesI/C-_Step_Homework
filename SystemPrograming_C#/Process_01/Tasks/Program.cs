using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter some text::::::) ");
            string str = Console.ReadLine();


            Task<int> task_Sumbol = new Task<int>(() => countOfSumbol(str));
            Task<int> task_Sentenses = new Task<int>(() => countOfSentenses(str));
            Task<int> task_Words = new Task<int>(() => countOfWords(str));
            Task<int> task_Sentenses_ASK = new Task<int>(() => countOfSentenses_ASK(str));
            Task<int> task_Sentenses_HZ = new Task<int>(() => countOfSentenses_HZ(str));

            task_Sumbol.Start();
            task_Sentenses.Start();
            task_Words.Start();
            task_Sentenses_ASK.Start();
            task_Sentenses_HZ.Start();

            Task.WaitAll();

            Console.WriteLine("1) Show; 2) Save in file");
            int choose = Int32.Parse(Console.ReadLine());
            if (choose == 1)
                Console.WriteLine($"Sumbol is {task_Sumbol.Result}\nSentenses is {task_Sentenses.Result + task_Sentenses_ASK.Result + task_Sentenses_HZ.Result}\nWords is {task_Words.Result}\nAsk {task_Sentenses_ASK.Result}\n! {task_Sentenses_HZ.Result}");
            else
            {
                Console.WriteLine("Write in file.txt");
                try
                {
                    using (StreamWriter sw = new StreamWriter("file.txt"))
                    {
                        sw.WriteLine($"Sumbol is {task_Sumbol.Result}\nSentenses is {task_Sentenses.Result + task_Sentenses_ASK.Result + task_Sentenses_HZ.Result}\nWords is {task_Words.Result}\nAsk {task_Sentenses_ASK.Result}\n! {task_Sentenses_HZ.Result}");
                    }

                    Console.WriteLine("Succses.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
        static int countOfSumbol(string text)
        {
            string symbolsToRemove = "!@#$%^&*()_+ ";
            string input = text;
            foreach (char symbol in symbolsToRemove)
            {
                input = input.Replace(symbol.ToString(), "");
            }

            return input.Length;
        }
        static int countOfWords(string text)
        {
            string symbolsToRemove = "!@#$%^&*()_+";
            string input = text;
            foreach (char symbol in symbolsToRemove)
            {
                input = input.Replace(symbol.ToString(), "");
            }
            return input.Split(' ').Length;
        }
        static int countOfSentenses(string text)
        {
            string str = text.Replace(" ", "");
            return str.Split('.').Length - 1;
        }
        static int countOfSentenses_ASK(string text)
        {
            string str = text.Replace(" ", "");
            return str.Split('?').Length - 1;
        }
        static int countOfSentenses_HZ(string text)
        {
            string str = text.Replace(" ", "");
            return str.Split('!').Length - 1;
        }
    }
}
