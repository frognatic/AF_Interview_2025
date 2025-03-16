using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AF_Interview.Items
{
    public class UserItemsFactoryProvider
    {
        [Inject]
        public UserItemsFactoryProvider()
        {
        }
        
        private readonly Dictionary<Type, IUserItemsFactory> _factories = new Dictionary<Type, IUserItemsFactory>()
        {
            { typeof(BonusItemSO), new BonusUserItemsFactory() },
            { typeof(ItemSO), new UserItemsFactory() }
        };

        public UserItem CreateItem(ItemSO data, int amount)
        {
            if (_factories.TryGetValue(data.GetType(), out IUserItemsFactory factory))
            {
                return factory.CreateUserItem(data, amount);
            }

            Debug.LogError($"Can't create item {data.GetType().Name}");
            return null;
        }
    }
}
