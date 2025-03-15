using System;
using System.Collections.Generic;
using System.Linq;
using AF_Interview.Items;
using AF_Interview.Utilities;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using Zenject;

namespace AF_Interview.Systems
{
    public class ItemSystem : SystemBase
    {
        #region Serialized Fields

        [SerializeField] protected ItemsLibrary _itemsLibrary;

        #endregion

        #region Injected Fields
        
        [Inject] private ItemsFactoryProvider _itemsFactoryProvider;

        #endregion

        #region Non-Serialized Fields

        private readonly List<Item> _items = new List<Item>();

        #endregion

        #region Properties

        public List<Item> Items => _items;

        #endregion
        
        #region Override Methods

        public override Type[] BindingContractTypes => new Type[]
        {
            typeof(ItemSystem)
        };
        public override void Construct()
        {

        }
        public override void InstallBindings(DiContainer container, MessagePipeOptions messagePipeOptions)
        {
            container.Bind<ItemsFactoryProvider>()
                .AsSingle();
        }

        public override async UniTask Init()
        {
            PrepareStartInventoryItems();
            
            IsReady = true;
            await UniTask.CompletedTask;
        }

        #endregion
        
        #region Public Methods
        
        public void AddItem(Item item, int amount)
        {
            
        }

        public void RemoveItem(Item item, int amountToRemove)
        {
            
        }

        public List<Item> GetAllAvailableItems()
        {
            return _items.Where(x => x.Amount > 0).ToList();
        }
        
        #endregion

        #region Private Methods
        
        private void PrepareStartInventoryItems()
        {
            foreach (var itemSO in _itemsLibrary.AllItems)
            {
                var item = _itemsFactoryProvider.CreateItem(itemSO, GetStartedItemAmount(itemSO));
                _items.Add(item);
            }
        }

        private int GetStartedItemAmount(ItemSO itemData)
        {
            var initialItemData = _itemsLibrary.InitialItemsData.Find(x => x.ItemData == itemData);

            if (initialItemData == null)
            {
                return 0;
            }
            
            var canProceed = RandUtilities.CanProceed(initialItemData.SpawnChance);
            return canProceed ? RandUtilities.GetRandomValueFromRange(initialItemData.SpawnAmountRange) : 0;
        }

        #endregion
    }
}
