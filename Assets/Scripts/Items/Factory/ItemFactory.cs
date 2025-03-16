namespace AF_Interview.Items
{
    public class UserItemsFactory : IUserItemsFactory
    {
        public UserItem CreateUserItem(ItemSO data, int amount)
        {
            return new UserItem(data, amount);
        }
    }
    
    public interface IUserItemsFactory
    {
        UserItem CreateUserItem(ItemSO data, int amount);
    }
}
