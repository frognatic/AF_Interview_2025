using System;
using System.Collections.Generic;
using UnityEngine;

namespace AF_Interview.Items.DataModels
{
    [Serializable]
    public class ItemsLibraryDataModel
    {
        #region Serialized Fields

        [SerializeField] protected List<ItemBase> _items = new();

        #endregion

        #region Properties

        public List<ItemBase> Items { get => _items; set => _items = value; }

        #endregion
    }
}
