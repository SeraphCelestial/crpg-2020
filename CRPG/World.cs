using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG
{
    public class World
    {
        public static readonly string WorldName = "Bjork";
        public static readonly List<Location> Locations = new List<Location>();

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_FOREST_PATH = 2;
        public const int LOCATION_ID_LAB = 3;

        static World()
        {
            PopulateLocations();
        }

        private static void PopulateLocations()
        {
            Location home = new Location(LOCATION_ID_HOME, "Home", "Your house is a mess");
            Location forestPath = new Location(LOCATION_ID_FOREST_PATH, "Forest Path", "A wooded path with lots of ferns.");
            Location lab = new Location(LOCATION_ID_LAB, "Lab", "A strange smelling lab with potions and rat tails.");

            home.LocationToNorth = forestPath;
            forestPath.LocationToSouth = home;
            forestPath.LocationToEast = lab;
            lab.LocationToWest = forestPath;

            Locations.Add(home);
            Locations.Add(forestPath);
            Locations.Add(lab);
        }
    }
}
