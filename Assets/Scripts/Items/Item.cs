using System;

namespace AF_Interview.Items
{
    [Serializable]
    public class Item: IItem
    {
        public ItemSO ItemData { get; set; }
        public int Amount { get; set; }

        public Item(ItemSO itemData, int amount)
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
