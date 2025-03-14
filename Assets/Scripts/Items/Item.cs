using System;
namespace AF_Interview.Items
{
    [Serializable]
    public class Item
    {
        public ItemBaseSO ItemData { get; set; }
        public int Amount { get; set; }

        public Item(ItemBaseSO itemData, int amount)
        {
            ItemData = itemData;
            Amount = amount;
        }
    }
}
