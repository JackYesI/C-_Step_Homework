using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Interface
{
    abstract class Disk : IDisk
    {
        string name;
        string memory;
        int sizemem;
        public string Memory { get { return memory; } set { memory = value; } }
        public int Size { get { return sizemem; } set { sizemem = value; } }
        public Disk(string name, string memory_ = "NoMemory", int size = 0)
        {
            Memory = memory_;
            Size = size;
            this.name = name;
        }
        public virtual string getName()
        {
            return name;
        }
        public string Read()
        {
            return ToString() + "\n" + $"Name is {name}" + "\n" + $"memory is {memory}" + "\n" + $"sizemem is {sizemem}";
        }

        public void Write(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine("Text has writed");
        }
    }
}
