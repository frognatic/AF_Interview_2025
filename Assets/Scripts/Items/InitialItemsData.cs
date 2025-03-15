using System;
using NaughtyAttributes;
using UnityEngine;

namespace AF_Interview.Items
{
    [Serializable]
    public class InitialItemsData
    {
        #region Serialized Fields
        
        [SerializeField] protected ItemSO _itemData;
        [MinMaxSlider(0, 99)]
        [SerializeField] protected Vector2Int _spawnAmountRange;
        [Range(0, 100f)]
        [SerializeField] protected int _spawnChance;
        
        #endregion

        #region Properties

        public ItemSO ItemData { get => _itemData; set => _itemData = value; }
        public Vector2Int SpawnAmountRange { get => _spawnAmountRange; set => _spawnAmountRange = value; }
        public int SpawnChance { get => _spawnChance; set => _spawnChance = value; }

        #endregion
    }
}
