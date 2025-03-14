using System;
using UnityEngine;

namespace AF_Interview.Items.DataModels
{
    [Serializable]
    public abstract class ItemBaseDataModel
    {
        #region Serialized Fields

        [SerializeField] protected int _itemId;
        [SerializeField] protected string _itemName;
        [SerializeField] protected string _itemDescription;

        #endregion

        #region Properties

        public int ItemId { get => _itemId; set => _itemId = value; }
        public string ItemName { get => _itemName; set => _itemName = value; }
        public string ItemDescription { get => _itemDescription; set => _itemDescription = value; }

        #endregion
    }
}
