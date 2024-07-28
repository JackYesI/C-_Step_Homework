using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Dictinaty
{
    internal class Player
    {
        private List<Carta> carty;
        public Player() { carty = new List<Carta>(); }
        public void InitCarty(List<Carta> carty)
        {
            this.carty = carty;
        }
        public Carta getCartu()
        {
            return carty.First();
        }
        public void popCatu()
        {
            carty.RemoveAt(0);
        }
        public void addCartu(Carta carta)
        {
            carty.Add(carta);
        }
        public bool isEmpty_()
        {
            return carty.Count == 0;
        }
        public int getCount()
        {
            return carty.Count;
        }
    }
}
