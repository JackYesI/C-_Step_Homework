using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colection
{
    class Data_Base<T>
    {
        public List<T> Workers { get; set; }
        public Data_Base(params T[] workers)
        {
            Workers = new List<T>();
            this.Workers.AddRange(workers);
        }
        public void addWorker(params T[] workers)
        {
            this.Workers.AddRange(workers);
        }
        public void popWorker(params T[] workers)
        {
            this.Workers.RemoveAll(workers.Contains);
        }
        public void editWorkers(T newWorker, string searchName)
        {
            if (Workers[0] is Worker || Workers == null) { return; }
            int index = Workers.FindIndex(el => (el as Worker).Name == searchName);
            if (index == -1)
                Console.WriteLine("Do not search worker with that name");
            else
            {
                this.popWorker(Workers[index]);
                this.addWorker(newWorker);
            }
        }
        public void PrintWorkers()
        {
            foreach (var item in Workers)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public List<T> SearchWorkers_Pay(short pay)
        {
            if (Workers[0] is Worker || Workers == null) { return null; }
            return Workers.FindAll(el => (el as Worker).Pay == pay);
        }
        public void sort()
        {
            Workers.Sort();
        }
    }
}
