using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AF_Interview.Items
{
    public class ItemsFactoryProvider
    {
        [Inject]
        public ItemsFactoryProvider()
        {
        }
        
        private readonly Dictionary<Type, IItemsFactory> _factories = new Dictionary<Type, IItemsFactory>()
        {
            { typeof(BonusItemSO), new BonusItemsFactory() },
            { typeof(ItemSO), new ItemsFactory() }
        };

        public Item CreateItem(ItemSO data, int amount)
        {
            if (_factories.TryGetValue(data.GetType(), out IItemsFactory factory))
            {
                return factory.CreateItem(data, amount);
            }

            Debug.LogError($"Can't create item {data.GetType().Name}");
            return null;
        }
    }
}
