using System.Collections.Generic;
using Zenject;

namespace AF_Interview.Items
{
    public interface IItemsFactory
    {
        List<Item> GetItems();
        void Init(List<Item> items);
    }
    
    public class ItemsFactory : IItemsFactory
    {
        private List<Item> _items = new List<Item>();

        [Inject]
        public ItemsFactory()
        {
        }
        
        public void Init(List<Item> items)
        {
            _items = items;
        }

        public List<Item> GetItems()
        {
            return _items;
        }
    }
}
