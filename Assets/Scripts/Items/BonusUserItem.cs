using System;

namespace AF_Interview.Items
{
    [Serializable]
    public class BonusUserItem : UserItem
    {
        public BonusType BonusType { get; set; }
        public int BonusValue { get; set; }
        public BonusUserItem(BonusItemSO itemData, int amount) : base(itemData, amount)
        {
            BonusType = itemData.BonusType;
            BonusValue = itemData.BonusValue;
        }
    }
}
