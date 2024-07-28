using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    internal class Program
    {
        static void PrintArray<T>(T[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j],10}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static T[,] CreateArray<T>(int size)
        {
            T[,] arr = new T[size, size];
            return arr;
        }
        static void InputArray(int[,] arr, int left = 0, int right = 100)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(left, right);
                }
            }
        }
        static int[][] createJugged(int row, int col)
        {
            int[][] tmp = new int[row][];
            for (int i = 0; i < row; i++)
            {
                tmp[i] = new int[col++];
            }
            return tmp;
        }
        static void FillJugged(int[][] arr, int left = 10, int right = 50)
        {
            var rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = rnd.Next(left, right + 1);
                }
            }
        }
        static void PrintJugged(int[][] arr)
        {
            foreach (var line in arr) 
            {
                foreach (var item in line)
                {
                    Console.Write($"{item,-10}");
                }
                Console.WriteLine();
            }
        }
        static void SwapRow(int[][] arr, int row1, int row2)
        {
            if (row1 >= 0 && row2 >= 0 && row1 < arr.Length && row2 < arr.Length)
            {
                int[] tmp = arr[row1];
                arr[row1] = arr[row2];
                arr[row2] = tmp;
            }
        }
        static T[][] MoveUp<T>(T[][] arr, int index = 2)
        {
            T[][] newArr = new T[arr.Length][];
            for (int i = 0; i < arr.Length; i++)
            {
                if (i + index > arr.Length - 1)
                    newArr[i] = arr[i + index - arr.Length];
                else
                    newArr[i] = arr[i + index];
            }
            return newArr;
        }
        static T[][] MoveDown<T>(T[][] arr, int index = 2)
        {
            T[][] newArr = new T[arr.Length][];
            for (int i = 0; i < arr.Length; i++)
            {
                if (i - index < 0)
                    newArr[i] = arr[i - index + arr.Length];
                else
                    newArr[i] = arr[i - index];
            }
            return newArr;
        }
        static void addRow(ref int[][] matrix, int[] newRow)
        {
            System.Array.Resize(ref matrix, matrix.Length + 1);
            matrix[matrix.Length - 1] = newRow;
        }

        static void FillLength(int[] arr, int left = -10, int right = 10)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(left, right);
            }
        }
        static void PrintLenght(int[] arr)
        {
            foreach (var item in arr)
            {
                  Console.WriteLine($"{item, 10}");
            }
        }
        static void popRow(ref int[][] matrix, int index = 0)
        {
            if (!(index < matrix.Length && index >= 0)) return;
            int[][] res = new int[matrix.Length - 1][];
            for (int i = 0; i < res.Length; i++)
            {
                if (i >= index)
                {
                    res[i] = matrix[i + 1];
                }
                else
                    res[i] = matrix[i];
            }
            matrix = res;

        }
        static void MaxAndMinJugged(int[][] matrix, out int max, out int min)
        {
            max = matrix[0][0];
            min = matrix[0][0];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (max < matrix[i][j]) max = matrix[i][j];
                    if (min > matrix[i][j]) min = matrix[i][j];
                }
            }
        }
        static int[][,] CreateAndInputRectangle(int lenght, int hight, int wight)
        {
            Random random = new Random();
            int[][,] res = new int[lenght][,];
            for (int i = 0; i < res.Length; i++)
            {
                int[,] arr = new int[hight,wight];
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    for (int k = 0; k < arr.GetLength(1); k++)
                    {
                        arr[j, k] = random.Next(-100, 100);
                    }
                }
                res[i] = arr;
            }
            return res;
        }
        static void PrintRectangle(int[][,] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"i :: {i}");
                PrintArray(arr[i]);
            }
        }
        static void SumRectangl(int[][,] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < arr[i].GetLength(0); j++)
                {
                    for (int k = 0; k < arr[i].GetLength(1); k++)
                    {
                        sum += arr[i][j, k];
                    }
                }
                Console.WriteLine($"sum on i({i}) :: {sum}");
            }
        }
        static void RemoveParams(ref string str, char[] params_)
        {
            for (int i = 0; i < params_.Length; i++)
            {
                int index = 0;
                index = str.IndexOf(params_[i]);
                while (index != -1)
                {
                    str = str.Remove(index, 1 );
                    index = str.IndexOf(params_[i], index);
                }


            }
        }
        static void CountLetters(string str)
        {
            int count = 0;
            int lenght = 90;
            for (int i = 65; i <= lenght; i++)
            {
                if (i == 90)
                {
                    i = 97;
                    lenght = 122;
                }
                count = str.Count(f => f == i);
                if (count != 0)
                {
                    Console.Write($"{Convert.ToChar(i)} [{count}] ");
                    while (count-- > 0)
                    {
                        Console.Write('*');
                    }Console.WriteLine();
                }
                    
                    
            }

        }
        static void Main(string[] args)
        {
            //int[][] array_ = createJugged(5, 5);
            //FillJugged(array_);
            //PrintJugged(array_);
            //int[] arr = new int[5];
            //FillLength(arr);
            //FillJugged(array_);
            //PrintJugged(array_);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //array_ = MoveUp(array_);
            //PrintJugged(array_);
            //array_ = MoveDown(array_);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //PrintJugged(array_);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //addRow(ref array_, arr);
            //PrintJugged(array_);
            //Console.WriteLine();
            //PrintLenght(arr);
            // pop
            //PrintJugged(array_);
            //popRow(ref array_, 1);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //PrintJugged(array_);

            // ex 2
            //int min, max;
            //MaxAndMinJugged(array_ , out max, out min);
            //Console.WriteLine($"Max {max} and min {min}");

            // ex *
            //int[][,] rectangl = CreateAndInputRectangle(5, 5, 5);
            //PrintRectangle(rectangl);
            //SumRectangl(rectangl);

            // str

            //System.String str = "Hello World";
            //char elem = 'o';
            //int index = 0;
            //while (true)
            //{
            //    index = str.IndexOf(elem, index + 1);
            //    if (index == -1) break;

            //    Console.WriteLine($"Elem index :: {index,10}");
            //}
            //Console.WriteLine(str.Replace(elem, Char.ToUpper(elem)));
            //index = str.LastIndexOf(elem);
            //Console.WriteLine(str.Remove(index));

            // 2

            //System.String str = "Hello World";
            //char[] params_ = new char[] { 'l', 'd' };
            //RemoveParams(ref str, params_);
            //Console.WriteLine(str);

            // 3

            //string source = "“I don’t know whether to delete this or rewrite it”";
            //CountLetters(source);

            // 4

            string[] keyWords = { "static", "ref", "int", "var" };
            string text = "static void Swap(ref int x,ref int y)\r\n        {\r\n            var tmp = x;\r\n            x = y;\r\n            y = tmp;\r\n        }";
            string[] result = text.Split(' ', ';', '\t', '\r', '\n', ')', '(', '.', ',', '[', ']', '}', '{', '=');

            //char[] par = { ' ', '\n', '\r', '\t' };
            int count = 0;
            
            List<string> list = new List<string>();
            List<int> count_ = new List<int>();
            for (int i = 0; i < keyWords.Length; i++)
            {
                count = result.Count(f => f == keyWords[i]);
                if (count != 0)
                {
                    
                    list.Add(keyWords[i]);
                    count_.Add(count);
                }

            }
            String[] str = list.ToArray();
            int[] num = count_.ToArray();

            Console.WriteLine("before sort :: ");
            foreach (var item in str)
            {
                Console.WriteLine(item);
            }

            // SORT
            System.Array.Sort(num ,str);

            Console.WriteLine();
            Console.WriteLine("After sort :: ");
            foreach (var item in str)
            {
                Console.WriteLine(item);
            }


        }
    }
}
