using System;
using System.Collections.Generic;
using AF_Interview.Items;
using AF_Interview.Utilities;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace AF_Interview.Systems
{
    public class ItemSystem : SystemBase
    {
        #region Serialized Fields

        [SerializeField] protected ItemsLibrary _itemsLibrary;

        #endregion

        #region Injected Fields

        [Inject] private IItemsFactory _itemsFactory;

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
            container.Bind<IItemsFactory>()
                .To<ItemsFactory>()
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
        
        public List<Item> GetItems() => _itemsFactory.GetItems();
        
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
            List<Item> itemSaveDataList = new();
            foreach (var startedItem in _itemsLibrary.GetItemsLibraryDataModel().InitialItems)
            {
                var shouldAdd = ProbabilityUtilities.IsSuccess(startedItem.SpawnChance);

                if (shouldAdd)
                {
                    // For Random.Range int maximum parameter is exclusive, so we need to add +1
                    var amount = Random.Range(startedItem.SpawnAmountRange.x, startedItem.SpawnAmountRange.y + 1);
                    
                    Item saveDataModel = new Item(startedItem.ItemData, amount);
                    itemSaveDataList.Add(saveDataModel);
                }
            }
            
            _itemsFactory.Init(itemSaveDataList);
        }

        #endregion
    }
}
