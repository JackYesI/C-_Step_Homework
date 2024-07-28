using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CSharpHome_1
{
    internal class Program
    {
        static void BuzzFizz(int number)
        {
            if (!(number > 1 && number < 100)) {
                Console.WriteLine("Error index out of range !!!");
                return;
            }
            if (number % 3 == 0) { Console.WriteLine("Fizz"); }
            else if (number % 5 == 0) { Console.WriteLine("Buzz"); }
            else if (number % 3 == 0 && number % 5 == 0) { Console.WriteLine("FizzBuzz"); }
            else { Console.WriteLine(number); }
        }
        static double Procent(int number, int procent)
        {
            double result = Convert.ToDouble(procent) * Convert.ToDouble(number) / 100;
            return result;
        }
        static double Unity()
        {
            Console.Write("Enter number :: ");
            String num = Console.ReadLine();
            double newNum = Convert.ToDouble(num) * 1000;
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter number :: ");
                num = Console.ReadLine();
                newNum += Convert.ToDouble(num) * Math.Pow(10, 2 - i);
            }
            
            return newNum;
        }
        static void Exersise_4()
        {
            Console.Write("Enter number :: ");
            string number = Console.ReadLine();
            if (number.Length != 6)
            {
                Console.WriteLine("Error");
                return;
            }
            Console.WriteLine("Enter for swap two numbers :: ");
            int index_1 = int.Parse(Console.ReadLine()) - 1;
            int index_2 = int.Parse(Console.ReadLine()) - 1;
            char[] num = new char[6];
            for (int i = 0; i < 6; i++)
            {
                num[i] = number[i];
            }
            char elem = number[index_1];
            num[index_1] = num[index_2];
            num[index_2] = elem;
            Console.WriteLine(num);
        }
        static void DateConverte()
        {
       
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            switch (month)
            {
                case 1:
                case 2:
                case 12:
                    Console.Write("Winter ");
                    break;
                case 3:
                case 4:
                case 5:
                    Console.Write("Spring ");
                    break;
                case 6:
                case 7:
                case 8:
                    Console.Write("Summer ");
                    break;
                case 9:
                case 10:
                case 11:
                    Console.Write("Autumn ");
                    break; 
            }
            var name_day = new DateTime(year, month, day);
            Console.WriteLine(name_day.DayOfWeek);
        }
        static double convertTemp(double temp)
        {
            Console.WriteLine("Enter (c0 or F0)");
            string choise = Console.ReadLine();
            if (choise == "c0")
            {
                return (temp * 1.8000) + 32;
            }
            if (choise == "F0")
            {
                return (temp - 32) / 1.8000;
            }
            return -1;
        }
        static void notOdd(int num_1, int num_2)
        {
            if (num_2 < num_1) Swap(ref num_1,ref num_2);
            for (int i = num_1; i < num_2; i++)
            {
                if (i % 2 == 0) Console.WriteLine(i);
            }
        }
        static void Swap(ref int x,ref int y)
        {
            var tmp = x;
            x = y;
            y = tmp;
        }
        static void Main(string[] args)
        {
            //BuzzFizz(95);
            //Console.WriteLine(Procent(100, 10));
            //Console.WriteLine("Result is :: " + Unity());
            //Exersise_4();
            //DateConverte();
            //Console.WriteLine(convertTemp(0));
            notOdd(30, 0);
        }
    }
}
