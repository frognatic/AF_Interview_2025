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

        public BonusType BonusType => _bonusType;
        public int BonusValue => _bonusValue;

        #endregion
    }
    
    public enum BonusType
    {
        CraftingSuccessRate,
        CraftingTimeReduce
    }
}
