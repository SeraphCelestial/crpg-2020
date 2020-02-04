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
        private static Player _player = new Player("Fred the Fearless", 10, 10, 20, 0, 1);
        static void Main(string[] args)
        {
            GameEngine.Initialize();
            _player.MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            InventoryItem sword = new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1);
            InventoryItem club = new InventoryItem(World.ItemByID(World.ITEM_ID_CLUB), 1);
            _player.Inventory.Add(sword);
            //_player.Inventory.Add(club);

            while (true)
            {
                Console.Write("> ");
                string userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    continue;
                }
                string cleanedInput = userInput.ToLower();
                if(cleanedInput == "exit")
                {
                    break;
                }
                ParseInput(cleanedInput);
            }
        }
        public static void ParseInput(string input)
        {
            if (input.Contains("help") || input == "h")
            {
                Console.WriteLine("Help (h): Displays this help message.");
                Console.WriteLine("North (n): Moves you north one space.");
                Console.WriteLine("South (s): Moves you south one space.");
                Console.WriteLine("East (e): Moves you east one space.");
                Console.WriteLine("West (w): Moves you west one space.");
                Console.WriteLine("Look (l): Displays information about the location you're currently in.");
                Console.WriteLine("Inventory (i): Displays the contents of your inventory.");
                Console.WriteLine("Stats (s): Displays your current stats.");
                Console.WriteLine("Quests (q): Displays all the quests you currently have.");
                Console.WriteLine("Attack (a): Makes you attack with your currently equipped weapon.");
                Console.WriteLine("Equip (eq): Allows you to change your currently equipped weapon.");
                Console.WriteLine("Weapons (wp): Displays all the weapons you currently have.");
            }
            else if (input.Contains("look") || input == "l")
            {
                DisplayCurrentLocation();
            }
            else if (input.Contains("north") || input == "n")
            {
                _player.MoveNorth();
            }
            else if (input.Contains("south") || input == "s")
            {
                _player.MoveSouth();
            }
            else if (input.Contains("east") || input == "e")
            {
                _player.MoveEast();
            }
            else if (input.Contains("west") || input == "w")
            {
                _player.MoveWest();
            }
            else if (input.Contains("debug"))
            {
                GameEngine.DebugInfo();
            }
            else if (input.Contains("inventory") || input == "i")
            {
                Console.WriteLine("\nCurrent Inventory:");
                foreach (InventoryItem invItem in _player.Inventory)
                {
                    Console.WriteLine("\t{0}: {1}", invItem.Details.Name, invItem.Quantity);
                }
            }
            else if (input == "stats" || input == "s")
            {
                Console.WriteLine("\nStats for {0}", _player.Name);
                Console.WriteLine("\tCurrent HP: \t{0}", _player.CurrentHitPoints);
                Console.WriteLine("\tMaximum HP: \t{0}", _player.MaximumHitPoints);
                Console.WriteLine("\tXP: \t\t{0}", _player.ExperiencePoints);
                Console.WriteLine("\tLevel: \t\t{0}", _player.Level);
                Console.WriteLine("\tGold: \t\t{0}", _player.Gold);
            }
            else if (input == ("quests") || input == "q")
            {
                if (_player.Quests.Count == 0)
                {
                    Console.WriteLine("You do not have any quests.");
                }
                else
                {
                    foreach (PlayerQuest playerQuest in _player.Quests)
                    {
                        Console.WriteLine("{0}: {1}", playerQuest.Details.Name, playerQuest.IsCompleted ? "Completed" : "Incomplete");
                    }
                }
            }
            else if (input.Contains("attack") || input == "a")
            {
                if (_player.CurrentLocation.MonsterLivingHere == null)
                {
                    Console.WriteLine("There is nothing here to attack");
                }
                else
                {
                    if (_player.CurrentWeapon == null)
                    {
                        Console.WriteLine("You are not equipped with a weapon.");
                    }
                    else
                    {
                        _player.UseWeapon(_player.CurrentWeapon);
                    }
                }
            }
            else if (input.StartsWith("equip ") || input == "eq")
            {
                _player.UpdateWeapons();
                string inputWeaponName = input.Substring(6).Trim();
                if (string.IsNullOrEmpty(inputWeaponName))
                {
                    Console.WriteLine("You must enter the name of the weapon to equip.");
                }
                else
                {
                    Weapon weaponToEquip = _player.Weapons.SingleOrDefault(x => x.Name.ToLower() == inputWeaponName || x.NamePlural.ToLower() == inputWeaponName);
                    if (weaponToEquip == null)
                    {
                        Console.WriteLine("You do not have the weapon {0}", inputWeaponName);
                    }
                    else
                    {
                        _player.CurrentWeapon = weaponToEquip;
                        Console.WriteLine("You equip your {0}", _player.CurrentWeapon.Name);
                    }
                }
            }
            else if (input == "weapons" || input == "wp")
            {
                _player.UpdateWeapons();
                Console.WriteLine("List of Weapons: ");
                foreach (Weapon w in _player.Weapons)
                {
                    Console.WriteLine("\t{0}", w.Name);
                }
            }
            else
            {
                Console.WriteLine("I don't understand. Sorry!");
            }
        }

        public static void DisplayCurrentLocation()
        {
            Console.WriteLine("\nYou are at: {0}", _player.CurrentLocation.Name);
            if (_player.CurrentLocation.Description != "")
            {
                Console.WriteLine("\t{0}\n", _player.CurrentLocation.Description);
            }
        }
    }
}
