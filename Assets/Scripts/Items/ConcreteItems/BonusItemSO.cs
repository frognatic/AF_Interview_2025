using AF_Interview.Items.DataModels;
using UnityEngine;

namespace AF_Interview.Items
{
    [CreateAssetMenu(fileName = "BonusItem", menuName = "Data/Items/BonusItem")]
    public class BonusItemSO : ItemBaseSO
    {
        #region Serialized Fields

        [SerializeField] private BonusItemDataModel _dataModel;

        #endregion

        #region Properties

        public new BonusItemDataModel GetDataModel() => _dataModel;
        protected override ItemBaseDataModel DataModel { get => _dataModel; set => _dataModel = value as BonusItemDataModel; }
        
        #endregion
    }
}
