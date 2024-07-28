using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Ivent_Game_delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Nissan_Skyline nissan = new Nissan_Skyline("Nissan Skyline Gt");
            Toyota_supra toyota = new Toyota_supra("Supra");

            Race race = new Race(nissan, toyota);

            race.Game_Delegate += nissan.drive;
            race.Game_Delegate += toyota.drive;
            nissan.ed += race.finishRacing;
            toyota.ed += race.finishRacing;

            race.Racing();
        }
    }
}
