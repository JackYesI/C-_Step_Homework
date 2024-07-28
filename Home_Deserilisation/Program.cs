using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace Serilization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            string json = wc.DownloadString("https://api.privatbank.ua/p24api/pubinfo?json");
            Console.WriteLine(json);

            //string check = "{\"Code\":\"USD\",\"Name\":\"US Dollar\",\"ExchangeRate\":1.0}";

            List<Currency> currencyList = JsonConvert.DeserializeObject<List<Currency>>(json);


            //foreach (var currency in currencyList)
            //{
            //    Console.WriteLine($"Ccy: {currency.Ccy}");
            //    Console.WriteLine($"Base_ccy: {currency.Base_ccy}");
            //    Console.WriteLine($"Buy: {currency.Buy}");
            //    Console.WriteLine($"Sale: {currency.Sale}");
            //    Console.WriteLine();
            //}

            Console.WriteLine("Choose your currency");
            int i = 0;
            foreach (var currency in currencyList)
            {
                i++;
                Console.WriteLine(currency.ToString() + $" - {i}");
            }
            Console.WriteLine();

            int choose = Convert.ToInt32(Console.ReadLine()) - 1;

            if (choose >= 0 && choose < currencyList.Count)
            {
                Console.WriteLine($"buying {currencyList[choose].Ccy} for {100} {currencyList[choose].Base_ccy,-10} is {currencyList[choose].Buy_(100)}");
                Console.WriteLine($"saling 100 {currencyList[choose].Ccy} for {currencyList[choose].Base_ccy,-10} is {currencyList[choose].Sale_(100)}");
            }
            
        }
    }
}
