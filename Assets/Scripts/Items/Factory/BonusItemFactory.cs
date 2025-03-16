namespace AF_Interview.Items
{
    public class BonusUserItemsFactory : IUserItemsFactory
    {
        public UserItem CreateUserItem(ItemSO data, int amount)
        {
            return new BonusUserItem((BonusItemSO)data, amount);
        }
    }
}
