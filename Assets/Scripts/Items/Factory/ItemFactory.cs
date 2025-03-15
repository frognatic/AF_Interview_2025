namespace AF_Interview.Items
{
    public class ItemsFactory : IItemsFactory
    {
        public Item CreateItem(ItemSO data, int amount)
        {
            return new Item(data, amount);
        }
    }
    
    public interface IItemsFactory
    {
        Item CreateItem(ItemSO data, int amount);
    }
}
