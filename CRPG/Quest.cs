﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG
{
    public class Quest
    {
        public int ID;
        public string Name;
        public string Description;
        public int RewardExperiencePoints;
        public int RewardGold;
        public Item RewardItem;
        public List<QuestCompletionItem> QuestCompletionItems;

        public Quest(int iD, string name, string description, int rewardExperiencePoints, int rewardGold)
        {
            ID = iD;
            Name = name;
            Description = description;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;

            QuestCompletionItems = new List<QuestCompletionItem>();
        }
    }
}
