using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Ivent_Game_delegates
{
    public class V8E : Enginne
    {
        public V8E() { this.Power = 323; }
    }
    public class Toyota_supra : Car
    {
        public Toyota_supra(string name) : base(name, new V8E()) { }
    }
}
