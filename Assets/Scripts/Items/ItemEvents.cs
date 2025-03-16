namespace AF_Interview.Items
{
    public abstract class ItemEventBase
    {
        public UserItem UserItem;
        public int Amount;
    }
    
    public class AddItemEvent : ItemEventBase {}
    public class RemoveItemEvent : ItemEventBase {}
}
