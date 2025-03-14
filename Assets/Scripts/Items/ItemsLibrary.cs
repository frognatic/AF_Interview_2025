using System;
using AF_Interview.Items.DataModels;
using UnityEngine;

namespace AF_Interview.Items
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Items Library", menuName = "Data/Items/Items Library")]
    public class ItemsLibrary : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField] private ItemsLibraryDataModel _itemsLibraryDataModel;

        #endregion

        #region Public Methods

        public ItemsLibraryDataModel GetItemsLibraryDataModel()
        {
            return _itemsLibraryDataModel;
        }

        #endregion
    }
}
