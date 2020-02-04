using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG
{
    public static class GameEngine
    {
        public static string Version = "0.0.4";
        public static Monster _currentMonster;

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
            if (_currentMonster != null)
            {
                Console.WriteLine("Current Monster: {0}", _currentMonster.Name);
            }
            else
            {
                Console.WriteLine("No current monster.");
            }
        }

        public static void QuestProcessor(Player _player, Location newLocation)
        {
            string questMessage;
            if (newLocation.QuestAvailableHere != null)
            {
                bool playerAlreadyHasQuest = _player.HasThisQuest(newLocation.QuestAvailableHere);
                bool playerAlreadyCompletedQuest = _player.CompletedThisQuest(newLocation.QuestAvailableHere);

                if (playerAlreadyHasQuest)
                {
                    if (!playerAlreadyCompletedQuest)
                    {
                        bool playerHasAllItemsToCompleteQuest = _player.HasAllQuestCompletionItems(newLocation.QuestAvailableHere);

                        if (playerHasAllItemsToCompleteQuest)
                        {
                            questMessage = Environment.NewLine;
                            questMessage += "You complete the '" + newLocation.QuestAvailableHere.Name + "' quest." + Environment.NewLine;

                            _player.RemoveQuestCompletionItems(newLocation.QuestAvailableHere);

                            questMessage += "You receive: " + Environment.NewLine;
                            questMessage += newLocation.QuestAvailableHere.RewardExperiencePoints.ToString() + " experience points" + Environment.NewLine;
                            questMessage += newLocation.QuestAvailableHere.RewardGold.ToString() + " gold" + Environment.NewLine;
                            questMessage += newLocation.QuestAvailableHere.RewardItem.Name + Environment.NewLine;
                            questMessage += Environment.NewLine;
                            Console.WriteLine(questMessage);

                            _player.ExperiencePoints += newLocation.QuestAvailableHere.RewardExperiencePoints;
                            _player.Gold += newLocation.QuestAvailableHere.RewardGold;

                            _player.AddItemToInventory(newLocation.QuestAvailableHere.RewardItem);

                            _player.MarkQuestCompleted(newLocation.QuestAvailableHere);
                        }
                    }
                }
                else
                {
                    questMessage = "You receive the " + newLocation.QuestAvailableHere.Name + " quest." + Environment.NewLine;
                    questMessage += newLocation.QuestAvailableHere.Description + Environment.NewLine;
                    questMessage += "To complete it, return with:" + Environment.NewLine;
                    foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            questMessage += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                        }
                        else
                        {
                            questMessage += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                        }
                    }
                    questMessage += Environment.NewLine;
                    Console.WriteLine(questMessage);

                    _player.Quests.Add(new PlayerQuest(newLocation.QuestAvailableHere, false));
                }
            }

        }

        public static void MonsterProcessor(Player player, Location newLocation)
        {
            string monsterMessage = "";
            if (newLocation.MonsterLivingHere != null)
            {
                monsterMessage += "You see a " + newLocation.MonsterLivingHere.Name + "\n";
                Console.WriteLine(monsterMessage);
                Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);
                _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaximumDamage, standardMonster.RewardExperiencePoints, standardMonster.RewardGold, standardMonster.CurrentHitPoints, standardMonster.MaximumHitPoints);
                foreach (LootItem lootItem in standardMonster.LootTable)
                {
                    _currentMonster.LootTable.Add(lootItem);
                }
            }
            else
            {
                _currentMonster = null;
            }
        }
    }
}
