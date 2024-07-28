using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Dictinaty
{
    class Game
    {
        private List<Player> players;
        private Dictionary<int, Carta> coloda;
        private bool isEnd()
        {
            int k = 0;
            foreach (Player item in players)
            {
                if (item.isEmpty_()) k += 1;
            }
            if (k == players.Count - 1) return true;
            else
                return false;
        }
        public Game(params Player[] pla)
        {
            players = new List<Player>(pla);
            coloda = new Dictionary<int, Carta>()
            {
                { 1, new Carta(Type.six, Mast.chirva) },
                { 2, new Carta(Type.seven, Mast.chirva) },
                { 3, new Carta(Type.eight, Mast.chirva) },
                { 4, new Carta(Type.nine, Mast.chirva) },
                { 5, new Carta(Type.ten, Mast.chirva) },
                { 6, new Carta(Type.valet, Mast.chirva) },
                { 7, new Carta(Type.dama, Mast.chirva) },
                { 8, new Carta(Type.king, Mast.chirva) },
                { 9, new Carta(Type.tuz, Mast.chirva) },

                { 10, new Carta(Type.six, Mast.pika) },
                { 11, new Carta(Type.seven, Mast.pika) },
                { 12, new Carta(Type.eight, Mast.pika) },
                { 13, new Carta(Type.nine, Mast.pika) },
                { 14, new Carta(Type.ten, Mast.pika) },
                { 15, new Carta(Type.valet, Mast.pika) },
                { 16, new Carta(Type.dama, Mast.pika) },
                { 17, new Carta(Type.king, Mast.pika) },
                { 18, new Carta(Type.tuz, Mast.pika) },

                { 19, new Carta(Type.six, Mast.booba) },
                { 20, new Carta(Type.seven, Mast.booba) },
                { 21, new Carta(Type.eight, Mast.booba) },
                { 22, new Carta(Type.nine, Mast.booba) },
                { 23, new Carta(Type.ten, Mast.booba) },
                { 24, new Carta(Type.valet, Mast.booba) },
                { 25, new Carta(Type.dama, Mast.booba) },
                { 26, new Carta(Type.king, Mast.booba) },
                { 27, new Carta(Type.tuz, Mast.booba) },

                { 28, new Carta(Type.six, Mast.hresta) },
                { 29, new Carta(Type.seven, Mast.hresta) },
                { 30, new Carta(Type.eight, Mast.hresta) },
                { 31, new Carta(Type.nine, Mast.hresta) },
                { 32, new Carta(Type.ten, Mast.hresta) },
                { 33, new Carta(Type.valet, Mast.hresta) },
                { 34, new Carta(Type.dama, Mast.hresta) },
                { 35, new Carta(Type.king, Mast.hresta) },
                { 36, new Carta(Type.tuz, Mast.hresta) }
            };

        }
        public void Random_Carty()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            SortedDictionary<int, Carta> coloda_for_del = new SortedDictionary<int, Carta>(coloda);
            int count_ = players.Count;
            for (int i = 0; i < 36; i++)
            {
                if (count_ == 0) count_ = players.Count;
                while (true)
                {
                    int num = random.Next(1, 37);
                    if (coloda_for_del.ContainsKey(num))
                    {
                        players[count_ - 1].addCartu(coloda_for_del[num]);
                        coloda_for_del.Remove(num);
                        count_ -= 1;
                        break;
                    }
                }
            }
        }
        public void DoGame()
        {
            while (!isEnd())
            {
                Console.WriteLine($"player 1 has carts {players[0].getCount()} " + players[0].getCartu().ToString() + "\t" + $"player 2 has carts {players[1].getCount()} " + players[1].getCartu().ToString());
                if (players[0].getCartu().Type >= players[1].getCartu().Type)
                {
                    players[0].addCartu(players[0].getCartu());
                    players[0].addCartu(players[1].getCartu());
                    players[0].popCatu();
                    players[1].popCatu();
                }
                else
                {
                    players[1].addCartu(players[1].getCartu());
                    players[1].addCartu(players[0].getCartu());
                    players[0].popCatu();
                    players[1].popCatu();
                }
            }
        }
    }
}
