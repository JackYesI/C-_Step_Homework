using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Ivent_Game_delegates
{
    public class GT344 : Enginne
    {
        public GT344() { this.Power = 344; }
    }
    public class Nissan_Skyline : Car
    {
        public Nissan_Skyline(string name) : base(name, new GT344()) { }
    }
}
