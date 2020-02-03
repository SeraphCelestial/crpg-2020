using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG
{
    public static class GameEngine
    {
        public static string Version = "0.0.3";

        public static void Initialize()
        {
            Console.WriteLine("Initializing Game Engine Version {0}", Version);
            Console.WriteLine("\n\nWelcome to the World of {0}", World.WorldName);
            Console.WriteLine();
        }

        public static void DebugInfo()
        {
            World.ListLocations();
            World.ListItems();
            World.ListMonsters();
            World.ListQuests();
        }
    }
}
