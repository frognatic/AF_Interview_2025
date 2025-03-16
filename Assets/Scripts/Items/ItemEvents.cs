namespace AF_Interview.Items
{
    public abstract class ItemEventBase
    {
        public Item Item;
        public int Amount;
    }
    
    public class AddItemEvent : ItemEventBase {}
    public class RemoveItemEvent : ItemEventBase {}
}
