using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Ivent_Game_delegates
{
    public delegate void GameDelegate();
    public delegate string Finish();
    public abstract class Enginne
    {
        public int Power { get; set; }
        public Enginne() { Power = 100; }
        public Enginne(int Power) { this.Power = Power; }

    }
    
    public abstract class Car : IComparable<Car> 
    {
        public string Name { get; set; }
        public Enginne enginne { get; set; }
        public int Speed {  get; set; }
        public int Destination { get; set; }
        public event Finish ed;
        protected int maxSpeed;
        public Car(string name, Enginne enginne) { Name = name; this.enginne = enginne; setMaxSpeed(); Speed = 0; }
        protected void setMaxSpeed()
        {
            this.maxSpeed = (int)(enginne.Power * 1.5);
        }
        public void drive()
        {
            Random random = new Random(this.maxSpeed);
            this.Speed = random.Next(this.maxSpeed);
            string str = ed.Invoke();
            if (!(str == "nobody win !!!")) Console.WriteLine($"Winner is {str}");
        }
        public int CompareTo(Car other)
        {
            return Speed.CompareTo(other.Speed);
        }
    }
}
