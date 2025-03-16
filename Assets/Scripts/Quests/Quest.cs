using System;
using System.Collections.Generic;
using System.Linq;
using AF_Interview.Items;

namespace AF_Interview.Quests
{
    [Serializable]
    public class Quest
    {
        public QuestSO QuestData { get; set; }
        public bool IsFinished => Progress.All(x => x.IsFinished);
        public List<QuestProgress> Progress { get; private set; }

        public Quest(QuestSO questData)
        {
            QuestData = questData;
            
            Progress = new List<QuestProgress>();
            
            foreach (var finishRequirement in questData.FinishRequirements)
            {
                Progress.Add(new QuestProgress
                {
                    RequiredItem = finishRequirement.Key,
                    CurrentValue = 0,
                    EndValue = finishRequirement.Value
                });
            }
        }

        public bool TryUpdateProgress(ItemSO itemData, int amount)
        {
            bool updated = false;
            foreach (var progress in Progress)
            {
                if (progress.RequiredItem == itemData)
                {
                    progress.CurrentValue += amount;
                    updated = true;
                }
            }
            
            return updated;
        }
    }

    [Serializable]
    public class QuestProgress
    {
        public ItemSO RequiredItem { get; set; }
        public int CurrentValue { get; set; }
        public int EndValue { get; set; }
        public bool IsFinished => CurrentValue >= EndValue;
    } 
}
