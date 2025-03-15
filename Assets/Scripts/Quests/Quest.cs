using System;
using System.Collections.Generic;

namespace AF_Interview.Quests
{
    [Serializable]
    public class Quest
    {
        public QuestSO QuestData { get; set; }
        public bool IsFinished { get; set; }
        public List<QuestProgress> Progress { get; private set; }

        public Quest(QuestSO questData)
        {
            QuestData = questData;
            IsFinished = false;
            
            Progress = new List<QuestProgress>();
            
            foreach (var finishRequirement in questData.FinishRequirements)
            {
                Progress.Add(new QuestProgress
                {
                    CurrentValue = 0,
                    EndValue = finishRequirement.Value
                });
            }
        }
    }

    [Serializable]
    public class QuestProgress
    {
        public int CurrentValue { get; set; }
        public int EndValue { get; set; }
    } 
}
