using UnityEngine;

namespace AF_Interview.Items
{
    [CreateAssetMenu(fileName = "BonusItem", menuName = "Data/Items/BonusItem")]
    public class BonusItem : ItemBase
    {
        #region Serialized Fields

        [SerializeField] private BonusItemDataModel _dataModel;

        #endregion

        #region Properties

        public new BonusItemDataModel GetDataModel() => _dataModel;
        
        #endregion
    }
}
