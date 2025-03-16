using System.Collections.Generic;
using AF_Interview.Crafting;
using AF_Interview.Items;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace AF_Interview.Quests
{
    [CreateAssetMenu(fileName = "Quest", menuName = "Data/Quests/Quest")]
    public class QuestSO : ScriptableObject
    {
        #region Serialized Fields
        
        [SerializeField] protected int _questId;
        [SerializeField] protected string _questName;
        [SerializeField] protected List<CraftingMachineSO> _craftingMachinesToUnlock;
        [SerializeField] protected SerializedDictionary<ItemSO, int> _finishRequirements;

        #endregion

        #region Properties
        
        public int QuestId => _questId;
        public string QuestName => _questName;
        public List<CraftingMachineSO> CraftingMachinesToUnlock => _craftingMachinesToUnlock;
        public SerializedDictionary<ItemSO, int> FinishRequirements => _finishRequirements;

        #endregion
    }
}
