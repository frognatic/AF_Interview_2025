using System;

namespace AF_Interview.Items
{
    [Serializable]
    public class UserItem: IItem
    {
        public ItemSO ItemData { get; set; }
        public int Amount { get; set; }

        public UserItem(ItemSO itemData, int amount)
        {
            ItemData = itemData;
            Amount = amount;
        }
    }

    public interface IItem
    {
        ItemSO ItemData { get; set; }
        int Amount { get; set; }
    }
}
