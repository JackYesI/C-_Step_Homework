using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicializatory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Db db = new Db();
            db.CreatePlaylist("Rock");
        }
    }
}
