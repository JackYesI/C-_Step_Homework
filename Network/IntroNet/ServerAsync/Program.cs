using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Before asynchronous operation");

        // Виклик асинхронної функції
        MyAsyncFunction();
        MyAsyncFunction();
        MyAsyncFunction();
        MyAsyncFunction();

        Console.WriteLine("After asynchronous operation");

        // Виконання інших дій після асинхронної операції
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Additional action {i}");
            await Task.Delay(1000); // Затримка на 1 секунду
        }
        Console.ReadLine();
    }

    static async Task MyAsyncFunction()
    {
        // Чекаємо 3 секунди
        await Task.Delay(3000);
        Console.WriteLine("Async operation completed!");
    }
}
