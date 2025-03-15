using System;
using System.Collections.Generic;
using UnityEngine;

namespace AF_Interview.Items
{
    [Serializable]
    [CreateAssetMenu(fileName = "ItemsLibrary", menuName = "Data/Items/ItemsLibrary")]
    public class ItemsLibrary : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField] protected List<ItemSO> _allItems = new();
        [SerializeField] protected List<InitialItemsData> _initialItemsData = new();

        #endregion

        #region Properties

        public List<ItemSO> AllItems { get => _allItems; set => _allItems = value; }
        public List<InitialItemsData> InitialItemsData { get => _initialItemsData; set => _initialItemsData = value; }

        #endregion
    }
}
