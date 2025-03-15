using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AF_Interview.Crafting
{
    public class CraftingMachinesFactoryProvider
    {
        [Inject]
        public CraftingMachinesFactoryProvider()
        {
        }
        
        private readonly Dictionary<Type, ICraftingMachinesFactory> _factories = new Dictionary<Type, ICraftingMachinesFactory>()
        {
            { typeof(CraftingMachineSO), new CraftingMachinesFactory() }
        };

        public CraftingMachine CreateCraftingMachine(CraftingMachineSO data, bool isUnlocked)
        {
            if (_factories.TryGetValue(data.GetType(), out ICraftingMachinesFactory factory))
            {
                return factory.CreateCraftingMachine(data, isUnlocked);
            }

            Debug.LogError($"Can't create item {data.GetType().Name}");
            return null;
        }
    }
}
