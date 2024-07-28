using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace Array_lenght
{
    internal class Program
    {
        static int[] CreateArr(int size)
        {
            int[] array = new int[size];
            return array;
        }
        static void FillRandArr(int[] arr, int left = 0, int right = 100)
        {
            if (left > right) Swap(ref left,ref right);
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(left, right + 1);
            }
        }
        static void PrintArray<T>(T[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item,10}");
            }Console.WriteLine();
        }
        static void Swap<T>(ref T x,ref T y)
        {
            T elem = x;
            x = y;
            y = elem;
        }
        static void replace_<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i += 2)
            {
                if (i + 2 > arr.Length) return;
                Swap<T>(ref arr[i],ref arr[i + 1]);
            }
        }
        static int Findpositive(int[] arr)
        {
            int val = Array.FindIndex(arr, isPositive);
            return val;
        }
        static bool isPositive(int a)
        {
            return a > 0;
        }
        static double Findpositive(double[] arr)
        {
            double val = Array.FindIndex(arr, isPositive);
            return val;
        }
        static bool isPositive(double a)
        {
            return a > 0;
        }
        static int count(int[] arr)
        {
            return arr.Count(item => item % 2 == 0);
        }
        static int returnIndex(int[] arr)
        {
            return Array.FindIndex(arr, item => item % 7 == 0);
        }
        static void Exersice_2(int[] arr)
        {
            Array.Copy(addArr(Array.FindAll(arr, isNegative), Array.FindAll(arr, isPositive)), arr, arr.Length);
        }
        static bool isNegative(int number)
        {
            return number <= 0;
        }
        static int[] addArr(int[] arr_1, int[] arr_2)
        {
            int[] arr = new int[arr_1.Length + arr_2.Length];
            int i_ = arr_1.Length;
            if (i_ == -1) i_ = 0;
            for (int i = 0; i < arr_1.Length; i++)
            {
                arr[i] = arr_1[i];
            }
            for (int i = 0; i < arr_2.Length; i++)
            {
                arr[i_++] = arr_2[i];
            }
            return arr;
        }
        static void Main(string[] args)
        {
            // 1
            //int[] arr = CreateArr(5);
            //PrintArray<int>(arr);
            //FillRandArr(arr);
            //PrintArray(arr);
            //Console.WriteLine();
            //replace_(arr);
            //PrintArray(arr);
            //int positive = Findpositive(arr);
            //if (positive != -1)
            //{
            //    Console.WriteLine($"First positive is {arr[positive]}");
            //}
            //else { Console.WriteLine("Do't find positive number in colection"); }
            //Console.WriteLine($"even numbers :: {count(arr)}");
            //int seven = returnIndex(arr);
            //if (seven != -1)
            //{
            //    Console.WriteLine($"First seven is {arr[seven]}");
            //}
            //else { Console.WriteLine("Do't find seven number in colection"); }

            // 2

            //int[] arr = CreateArr(5);
            //FillRandArr(arr, -10, 10);
            //PrintArray(arr);
            //Exersice_2(arr);
            //PrintArray(arr);

            // 3

            int[] arr = CreateArr(10);
            FillRandArr(arr);
            PrintArray(arr);
            Console.Write("Enter number :: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(arr.Count(a => a == number));
        }
    }
}
