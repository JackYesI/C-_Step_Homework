using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Ivent_Game_delegates
{
    internal class Race
    {
        public Race(params Car[] cars) { racingCar = new HashSet<Car>(cars); }
        public HashSet<Car> racingCar;
        public event GameDelegate Game_Delegate;
        public void Racing()
        {
            Game_Delegate.Invoke();
        }
        public string finishRacing()
        {
            bool anySpeedNull = racingCar.Any(s => s.Speed == 0);
            if (anySpeedNull) { return "nobody win !!!"; }
            
            while (true)
            {
                if (racingCar.Any(s => s.Destination >= 1000))
                {
                    foreach (var item in racingCar)
                    {
                        if (item.Destination >= 1000) return item.Name;
                    }
                }
                foreach (var kvp in racingCar)
                {
                    kvp.Destination += (kvp.Speed * 1000) / 3600;
                    Console.WriteLine($"Car Name is {kvp.Name} and destination is {kvp.Destination} km");
                }
            }
            
        }
    }
}
