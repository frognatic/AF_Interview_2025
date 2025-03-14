using AF_Interview.Items;
using AF_Interview.Items.DataModels;
using UnityEngine;

namespace AF_Interview
{
    [CreateAssetMenu(fileName = "CraftedItem", menuName = "Data/Items/CraftedItem")]
    public class CraftedItemSO : ItemBaseSO
    {
        #region Serialized Fields

        [SerializeField] private CraftedItemDataModel _dataModel;

        #endregion

        #region Properties

        public new CraftedItemDataModel GetDataModel() => _dataModel;
        protected override ItemBaseDataModel DataModel { get => _dataModel; set => _dataModel = value as CraftedItemDataModel; }
        
        #endregion
    }
}
