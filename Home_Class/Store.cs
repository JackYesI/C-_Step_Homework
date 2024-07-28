using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    internal class Store
    {
        private string name;
        private string description;
        private string email;
        private string number;
        public Store()
        {
            name = string.Empty;
            description = string.Empty;
            number = string.Empty;
            email = string.Empty;
            adress = "";
        }
        public string Name { get { return name; } set { name = value; } }
        public string adress { get; set; }

        public string Description { get { return description; } set { description = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Number { get { return number; } set { number = value; } }
        public void InputStore(string name, string description, string email, string number, string adress)
        {
            this.name = name;
            this.description = description;
            this.email = email;
            this.number = number;
            
        }
        public override string ToString()
        {
            return $"Name :: {name}\nDescription :: {description}\nEmail :: {email}\nNumber :: {number}\nAdress :: {adress}"; ;
        }
        public void PrintStore()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
