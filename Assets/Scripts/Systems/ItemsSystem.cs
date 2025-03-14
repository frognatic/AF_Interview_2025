using System;
using System.Collections.Generic;
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

        [Inject] private IItemsService _itemsService;

        #endregion
        
        #region Non-serialized Fields

        private List<ResourcesItemSO> _resourcesItemList = new();
        private List<CraftedItemSO> _craftedItemList = new();

        #endregion

        #region Properties

        public List<ResourcesItemSO> ResourcesItemList => _resourcesItemList;

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
            container.Bind<IItemsService>()
                .To<ItemsService>()
                .AsSingle();
        }

        public override async UniTask Init()
        {
            PrepareResources().Forget();
            PrepareStartInventoryItems();
            
            IsReady = true;
            await UniTask.CompletedTask;
        }

        #endregion
        
        #region Public Methods
        
        public List<Item> GetItems() => _itemsService.GetItems();
        
        #endregion

        #region Private Methods

        private async UniTaskVoid PrepareResources()
        {
            foreach (var item in _itemsLibrary.GetItemsLibraryDataModel().Items)
            {
                if (item is ResourcesItemSO resourcesItem)
                {
                    _resourcesItemList.Add(resourcesItem);
                }

                if (item is CraftedItemSO craftedItem)
                {
                    _craftedItemList.Add(craftedItem);
                }
            }
            
            await UniTask.CompletedTask;
        }

        private void PrepareStartInventoryItems()
        {
            List<Item> initialItems = new();
            foreach (var startedItem in _itemsLibrary.GetItemsLibraryDataModel().InitialItems)
            {
                var shouldAdd = RandUtilities.CanProceed(startedItem.SpawnChance);

                if (shouldAdd)
                {
                    var amount = RandUtilities.GetRandomValueFromRange(startedItem.SpawnAmountRange);
                    
                    Item item = new Item(startedItem.ItemData, amount);
                    initialItems.Add(item);
                }
            }
            
            _itemsService.Init(initialItems);
        }

        #endregion
    }
}
