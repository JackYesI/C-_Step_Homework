using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Date
    {
        public uint year;
        public uint month;
        public uint day;
        public Date()
        {
            year = 2000;
            month = 1;
            day = 1;
        }
        public Date(uint year, uint month, uint day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }
        public override string ToString()
        {
            return $"Date is {day}.{month}.{year}";
        }
        public void InputDate(uint year, uint month, uint day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }

    }
    public class Magazine
    {
        private string name = string.Empty;
        private string description = string.Empty;
        private string email = string.Empty;
        private Date date;
        private string number = string.Empty;
        public Magazine() { }
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Date { get { return date.ToString(); } }
        public string Number { get { return number; } set { number = value; } }
        public void setDate(uint  year, uint month, uint day)
        {
            date.year = year;
            date.month = month;
            date.day = day;

        }
        public void InputMagazine(string name, string description, string email, string number, Date date)
        {
            this.name = name;
            this.description = description;
            this.email = email;
            this.number = number;
            this.date = date;
        }
        public override string ToString()
        {
            return $"Name :: {name}\nDescription :: {description}\nEmail :: {email}\nNumber :: {number}\nDate :: {date.ToString()}";
        }
        public void PrintMagazine()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
