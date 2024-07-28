using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseInterfaces
{
    class Director : ICloneable
    {
        private string First_name;
        private string Last_name;
        public Director(string First_name, string Last_name)
        {
            this.First_name = First_name;
            this.Last_name = Last_name;
        }
        public override string ToString()
        {
            return $"Director name {First_name + Last_name}";
        }
        public Object Clone()
        {
            return new Director(this.First_name, this.Last_name);
        }
    }
}
