using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_Exception
{
    internal class CreditCard
    {
        private string name;
        private ulong number;
        private DateTime date;
        private ushort cvv;
        public string Name { get { return name; }
            set 
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException();
                name = value;
            }
        }
        public ulong Number { get { return number; }
        set
            {
                if (value.ToString().Length != 16) throw new Exception("Error must be 16 numbers !!!");
                number = value;
            }
        }
        public DateTime Date { get { return date; }
            set
            {
                if (value.Date < DateTime.Now) throw new Exception("Not correct date of card !!!");
                date = value;
            }
        }
        public ushort CVV { get { return cvv; } 
            set
            {
                if (value.ToString().Length != 3) throw new Exception("Error must be 3 numbers !!!");
                cvv = value;
            }
        }
        public CreditCard(string name, ulong number, DateTime date, ushort cvv)
        {
            try
            {
                Name = name;
                Number = number;
                Date = date;
                CVV = cvv;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally block !!!");
            }
        }

        public override string ToString()
        {
            return $"Credit card name is {Name}\nCredit card number is {Number}\nCredit card Date {Date.Date}\nCredit card CVV is {CVV}\n";
        }
    }
}
