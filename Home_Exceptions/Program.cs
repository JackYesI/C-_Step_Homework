using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_Exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ex 1
            Account acount = new Account("he@lLo1", "vreverc1jwec");

            // ex 2
            acount.InputInterface();

            // ex 3*
            DateTime dateTime = new DateTime(2024, 5, 25);

            // class's constructor CreditCard
            CreditCard creditCard = new CreditCard("Transel bank", 1111222233334444, dateTime, 111);
            Console.WriteLine(creditCard.ToString());
            // set() variables of class CreditCard
            try
            {
                creditCard.Name = "Transel bank";
                creditCard.Number = 1111222233334444;
                creditCard.Date = dateTime;
                creditCard.CVV = 111;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally block demostration");
            }
        }
    }
}
