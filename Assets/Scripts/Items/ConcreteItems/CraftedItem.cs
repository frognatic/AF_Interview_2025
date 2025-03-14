using AF_Interview.Items;
using UnityEngine;

namespace AF_Interview
{
    [CreateAssetMenu(fileName = "CraftedItem", menuName = "Data/Items/CraftedItem")]
    public class CraftedItem : ItemBase
    {
        #region Serialized Fields

        [SerializeField] private CraftedItemDataModel _dataModel;

        #endregion

        #region Properties

        public new CraftedItemDataModel GetDataModel() => _dataModel;
        
        #endregion
    }
}
