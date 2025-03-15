using System;

namespace AF_Interview.Items
{
    [Serializable]
    public class BonusItem : Item
    {
        public BonusType BonusType { get; set; }
        public BonusItem(BonusItemSO itemData, int amount) : base(itemData, amount)
        {
            
        }
    }
}
