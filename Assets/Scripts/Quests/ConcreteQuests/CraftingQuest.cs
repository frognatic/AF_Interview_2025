using System;
using System.Collections.Generic;

namespace AF_Interview.Quests
{
    [Serializable]
    public class CraftingQuest : Quest
    {
        public CraftingQuest(CraftingQuestSO questData, bool isFinished = false) : base(questData, isFinished)
        {
            
        }

        private List<QuestProgress> _progress;

        public override List<QuestProgress> Progress 
        { 
            get
            {
                if (_progress == null || _progress.Count == 0) 
                {
                    _progress = new List<QuestProgress>();
                    var questData = (CraftingQuestSO)QuestData;
            
                    foreach (var finishRequirement in questData.GetDataModel().FinishRequirements)
                    {
                        _progress.Add(new QuestProgress
                        {
                            CurrentValue = 0,
                            EndValue = finishRequirement.Value
                        });
                    }
                }
                return _progress;
            }
            set => _progress = value;
        }
    }
}
