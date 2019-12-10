using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG
{
    //Made by Trayden Gerik 2019
    class Program
    {
        private static Player _player = new Player();
        static void Main(string[] args)
        {
            GameEngine.Initialize();
            _player.Name = "Dread";
            Console.ReadKey();
        }
    }
}
