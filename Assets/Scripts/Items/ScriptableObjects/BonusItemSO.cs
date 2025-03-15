using UnityEngine;

namespace AF_Interview.Items
{
    [CreateAssetMenu(fileName = "BonusItem", menuName = "Data/Items/BonusItem")]
    public class BonusItemSO : ItemSO
    {
        #region Serialized Fields

        [SerializeField] protected BonusType _bonusType;
        [SerializeField] protected int _bonusValue;

        #endregion
        
        #region Properties

        public BonusType BonusType { get => _bonusType; set => _bonusType = value; }
        public int BonusValue { get => _bonusValue; set => _bonusValue = value; }
        
        #endregion
    }
    
    public enum BonusType
    {
        CraftingSuccessRate,
        CraftingTimeReduce
    }
}
