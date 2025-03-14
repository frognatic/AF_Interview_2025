using System.Collections.Generic;
using Zenject;

namespace AF_Interview.Items
{
    public interface IItemsService
    {
        List<Item> GetItems();
        void Init(List<Item> items);
    }
    
    public class ItemsService : IItemsService
    {
        private List<Item> _items = new List<Item>();

        [Inject]
        public ItemsService()
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
