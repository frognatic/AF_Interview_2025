using AF_Interview.Items;
using UnityEngine;

namespace AF_Interview.Crafting
{
    [CreateAssetMenu(fileName = "CraftingMachine", menuName = "Data/Crafting/CraftingMachine")]
    public class CraftingMachine : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField] private CraftedItemDataModel _dataModel;

        #endregion

        #region Properties

        public CraftedItemDataModel GetDataModel() => _dataModel;
        
        #endregion
    }
}
