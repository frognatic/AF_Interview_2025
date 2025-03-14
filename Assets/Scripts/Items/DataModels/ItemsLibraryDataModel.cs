using System;
using System.Collections.Generic;
using UnityEngine;

namespace AF_Interview.Items.DataModels
{
    [Serializable]
    public class ItemsLibraryDataModel
    {
        #region Serialized Fields

        [SerializeField] protected List<ItemBaseSO> _items = new();
        [SerializeField] protected List<InitialItemsDataModel> _initialItems = new();

        #endregion

        #region Properties

        public List<ItemBaseSO> Items { get => _items; set => _items = value; }
        public List<InitialItemsDataModel> InitialItems { get => _initialItems; set => _initialItems = value; }

        #endregion
    }
}

