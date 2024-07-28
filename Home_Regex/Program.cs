using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace Regular
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            //Regex regex = new Regex(@"\b[0-9]{4}\b");
            //MatchCollection match = regex.Matches("1231 1241 3452 1 100 123241");
            //foreach (Match m in match)
            //{
            //    Console.WriteLine(m.Value);
            //}
            //

            // 2
            //Regex regex_2 = new Regex(@"\b([a-z]{3}[0-9]{3}){2}\b");
            //string[] words = new string[] { "qwe123rty456", "123wec345gtr", "12dw32wd" };
            //foreach (string word in words)
            //{
            //    if (regex_2.IsMatch(word))
            //    {
            //        Console.WriteLine(word);
            //    }
            //}
            //

            // 3
            //Regex regex_3 = new Regex(@"\b[A-Z]{3}\b");
            //string text = "I am creating PDF regular Exception for Caption letter WWW";
            //MatchCollection match = regex_3.Matches(text);
            //foreach (Match m in match)
            //{
            //    Console.WriteLine(m.Value);
            //}
            //

            // 4
            //Regex regex_4 = new Regex(@"(19)[0-9]{2}|(20)[0-9]{2}");
            //string[] years = new string[] { "1932", "1959", "1817", "2099" };
            //foreach (string year in years)
            //{
            //    if (regex_4.IsMatch(year))
            //    {
            //        Console.WriteLine(year);
            //    }
            //}
            //

            // 5
            Regex regex = new Regex(@"^\+[0-9]{2}\s*[0-9,*]{10}$");
            string number = string.Empty;

            while (true)
            {
                Console.Write("Enter number (+** **********) for example (+38 0965878222) also 10 last number may be a symbol (*) :: ");
                number = Console.ReadLine();
                if (regex.IsMatch(number)) break;
            }
            // до цього моменту було здійсненно ввід користувачем формату для пошуку, 
            // тобто строку типу +38 096****22* 
            // для пошуку таких чисел де * - будь-яке число

            number = number.Replace(" ", "");
            int count = 0;
            string result = @"^\+38\s?";
            for (int i = 3; i < number.Length; i++)
            {
                if (number[i] == '*')
                {
                    count++;
                    if (i + 1 != number.Length)
                    {
                        if (number[i + 1] != '*')
                        {
                            result += $"[0-9]{{{count}}}";
                        }
                    }
                    else
                        result += $"[0-9]{{{count}}}";
                    continue;
                }
                else
                {
                    count = 0;
                }
                result += number[i];
            }
            // тепер в змінній result лежить регулярний вираз для пошуку відповідних номерів телефонів
            Console.WriteLine(result);

            Regex regex_ = new Regex(result);

            //if (regex.IsMatch("+389658782629")) { Console.WriteLine("Let us drink"); }

            string[] numbers = new string[1000];
            for (int i = 0; i < 1000; i++)
            {
                string num = "+38";
                Random random = new Random(i);
                for (int j = 0; j < 10; j++)
                {
                    num += random.Next(0, 10).ToString();
                }
                numbers[i] = num;
            }

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
                //Console.WriteLine(item.GetType());
            }

            Console.WriteLine();
            Console.WriteLine();

            foreach (var item in numbers)
            {
                if (regex_.IsMatch(item))
                {
                    Console.WriteLine(item);
                }
            }

            //

        }
    }
}
