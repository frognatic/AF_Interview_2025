using System;
using System.Collections.Generic;
using AF_Interview.Crafting;
using UnityEngine;

namespace AF_Interview.Quests
{
    [Serializable]
    public class QuestBaseDataModel
    {
        #region Serialized Fields

        [SerializeField] protected int _questId;
        [SerializeField] protected string _questName;
        [SerializeField] protected QuestsTypes _questType;
        [SerializeField] protected List<CraftingMachine> _craftingMachinesToUnlock;

        #endregion

        #region Properties

        public int QuestId { get => _questId; set => _questId = value; }
        public string QuestName { get => _questName; set => _questName = value; }
        public QuestsTypes QuestType { get => _questType; set => _questType = value; }
        public List<CraftingMachine> CraftingMachinesToUnlock { get => _craftingMachinesToUnlock; set => _craftingMachinesToUnlock = value; }

        #endregion
    }

    public enum QuestsTypes
    {
        Craft
    }
}
