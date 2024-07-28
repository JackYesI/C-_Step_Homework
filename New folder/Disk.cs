using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_Interfaces
{
    internal class Disk : IDisk
    {
        string memory;
        int sizemem;
        public string Memory { get { return memory; } set { memory = value; } }
        public int Size { get { return sizemem;} set { sizemem = value; } }
        public Disk(string memory_ = "NoMemory", int size = 0)
        {
            Memory = memory_;
            Size = size;
        }
        public virtual string getName()
        {
            return this.ToString();
        }
        public string Read()
        {
            return getName() + $"\nmemory is {this.memory}\nsize is {this.sizemem}\n";
        }

        public void Write(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine("Text has writed");
        }
    }
}
