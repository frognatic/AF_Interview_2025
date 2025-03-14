using System;
using AF_Interview.Items;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace AF_Interview.Quests
{
    [Serializable]
    public class CraftingQuestDataModel : QuestBaseDataModel
    {
        #region Serialized Fields
        
        [SerializeField] protected SerializedDictionary<ItemBase, int> _finishRequirements;

        #endregion

        #region Properties 
        
        public SerializedDictionary<ItemBase, int> FinishRequirements { get => _finishRequirements; set => _finishRequirements = value; }
        
        #endregion
    }
}
