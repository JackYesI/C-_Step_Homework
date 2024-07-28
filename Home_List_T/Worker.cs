using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Colection
{
    class Worker : ICloneable, IComparable
    {
        public string Name { get; set; }
        public string Position { get; set; }
        private string gmail;
        private short pay;
        public string Gmail
        {
            get { return gmail; }
            set
            {
                Regex regex = new Regex(@"^[a-zA-Z0-9_]*@[a-zA-Z0-9_]*$");
                if (!(value.Length >= 4 && value.Length <= 50))
                    throw new Exception("Do not correct size [4;50] -> must be");
                if (!regex.IsMatch(value))
                    throw new Exception("Error value must be only number or leter or symbol \"_\"");
                gmail = value;
            }
        }
        public short Pay { get { return pay; }
            set
            {
                if (value <= 0) throw new Exception(">= 0 must be pay");
                pay = value;
            } }
        public Worker()
        {
            Name = "NoName";
            Position = "NoPosition";
            Gmail = "123tank@gmail_com";
            Pay = 1000;
        }
        public Worker(string name, string position, string gmail, short pay)
        {
            Name = name;
            Position = position;
            Gmail = gmail;
            Pay = pay;
        }

        public object Clone()
        {
            return new Worker(Name, Position, Gmail, Pay);
        }

        public int CompareTo(object obj)
        {
            if (obj is Worker)
                return this.Pay.CompareTo((obj as Worker).Pay);
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"Name is {Name}\nPosition is {Position}\nGmail{Gmail}\nPay{Pay}\n";
        }
    }
}
