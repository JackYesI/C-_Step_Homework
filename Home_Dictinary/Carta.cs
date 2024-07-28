using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Dictinaty
{
    internal class Carta
    {
        public Type Type { get; }
        public Mast Mast { get; }
        public Carta(Type Type, Mast Mast)
        {
            this.Type = Type;
            this.Mast = Mast;
        }
        public void printCarta()
        {
            Console.WriteLine($"Type is {Type} and Mast is {Mast}\n");
        }
        public override string ToString()
        {
            return $"Mast is {Mast} and Type is {Type}";
        }
    }
}
