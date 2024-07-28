using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_ForEach
{
    internal class Program
    {
        static int Factorial(int n)
        {
            if (n == 0)
                return 1;
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        static async Task<List<int>> ReadNumbersFromFileAsync(string filePath)
        {
            List<int> numbers = new List<int>();

            try
            {
                string fileContent = File.ReadAllText(filePath);

                string[] numberStrings = fileContent.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                await Task.WhenAll(Array.ConvertAll(numberStrings, async numberString =>
                {
                    if (int.TryParse(numberString, out int number))
                    {
                        await Task.Run(() =>
                        {
                            lock (numbers)
                            {
                                numbers.Add(number);
                            }
                        });
                    }
                    else
                    {
                        Console.WriteLine($"not number: {numberString}");
                    }
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }

            return numbers;
        }
        static async Task Main(string[] args)
        {
            List<int> list = await ReadNumbersFromFileAsync("number.txt");
            Parallel.ForEach(list, elem =>
            {
                Console.WriteLine($"Thread {Task.CurrentId} processing number {Factorial(elem)}");
            });
        }
    }
}
