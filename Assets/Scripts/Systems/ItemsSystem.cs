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
        
        [Inject] private readonly IPublisher<AddItemEvent> _addItemEventPublisher;
        [Inject] private readonly IPublisher<RemoveItemEvent> _removeItemEventPublisher;
        
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
            container.BindMessageBroker<AddItemEvent>(messagePipeOptions);
            container.BindMessageBroker<RemoveItemEvent>(messagePipeOptions);
            
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
        
        public void AddItem(ItemSO itemData, int amount)
        {
            var itemToAdd = _items.Find(x => x.ItemData == itemData);
            itemToAdd.Amount += amount;
            
            _addItemEventPublisher.Publish(new() { Item = itemToAdd, Amount = amount });
        }

        public void RemoveItem(ItemSO itemData, int amountToRemove)
        {
            var itemToDecreaseAmount = _items.Find(x => x.ItemData == itemData);
            itemToDecreaseAmount.Amount = Mathf.Clamp(itemToDecreaseAmount.Amount -= amountToRemove, 0, int.MaxValue);
            
            _removeItemEventPublisher.Publish(new() { Item = itemToDecreaseAmount, Amount = amountToRemove });
        }

        public bool HasRequiredItemAmount(ItemSO item, int amount)
        {
            var allAvailableItems = GetAllAvailableItems();

            var requiredItem = allAvailableItems.Find(x => x.ItemData == item);

            if (requiredItem == null)
            {
                return false;
            } 
            return requiredItem.Amount >= amount;
        }

        public List<Item> GetAllAvailableItems()
        {
            return _items.Where(x => x.Amount > 0).ToList();
        }
        
        public List<BonusItem> GetAllAvailableBonusItems()
        {
            return _items.OfType<BonusItem>().ToList();
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
