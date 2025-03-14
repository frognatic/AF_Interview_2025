using System;
using System.Collections.Generic;

namespace AF_Interview.Quests
{
    [Serializable]
    public abstract class Quest
    {
        public QuestBaseSO QuestData { get; set; }
        public bool IsFinished { get; set; }
        public abstract List<QuestProgress> Progress { get; set; }

        public Quest(QuestBaseSO questData, bool isFinished = false)
        {
            QuestData = questData;
            IsFinished = isFinished;
        }
    }

    [Serializable]
    public class QuestProgress
    {
        public int CurrentValue { get; set; }
        public int EndValue { get; set; }
    } 
}
