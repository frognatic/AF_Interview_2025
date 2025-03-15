namespace AF_Interview.Items
{
    public class BonusItemsFactory : IItemsFactory
    {
        public Item CreateItem(ItemSO data, int amount)
        {
            return new BonusItem((BonusItemSO)data, amount);
        }
    }
}
