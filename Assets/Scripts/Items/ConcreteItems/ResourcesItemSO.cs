using AF_Interview.Items.DataModels;
using UnityEngine;

namespace AF_Interview.Items
{
    [CreateAssetMenu(fileName = "ResourceItem", menuName = "Data/Items/ResourceItem")]
    public class ResourcesItemSO : ItemBaseSO
    {
        #region Serialized Fields

        [SerializeField] private ResourceItemDataModel _dataModel;

        #endregion

        #region Properties

        public new ResourceItemDataModel GetDataModel() => _dataModel;
        protected override ItemBaseDataModel DataModel { get => _dataModel; set => _dataModel = value as ResourceItemDataModel; }
        
        #endregion
    }
}
