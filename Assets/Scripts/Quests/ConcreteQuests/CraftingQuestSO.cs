using UnityEngine;

namespace AF_Interview.Quests
{
    [CreateAssetMenu(fileName = "CraftingQuest", menuName = "Data/Quests/CraftingQuest")]
    public class CraftingQuestSO : QuestBase
    {
        #region Serialized Fields

        [SerializeField] private CraftingQuestDataModel _dataModel;

        #endregion

        #region Properties

        public new CraftingQuestDataModel GetDataModel() => _dataModel;
        
        #endregion
    }
}
