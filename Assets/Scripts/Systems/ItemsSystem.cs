using System;
using System.Collections.Generic;
using AF_Interview.Items;
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

        #region Non-serialized Fields

        private List<ResourcesItem> _resourcesItemList = new();
        private List<CraftedItem> _craftedItemList = new();

        #endregion

        #region Properties

        public List<ResourcesItem> ResourcesItemList => _resourcesItemList;

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

        }

        public override async UniTask Init()
        {
            PrepareResources().Forget();
            
            IsReady = true;
            await UniTask.CompletedTask;
        }

        #endregion
        
        #region Public Methods
        
        #endregion

        #region Private Methods

        private async UniTaskVoid PrepareResources()
        {
            foreach (var item in _itemsLibrary.GetItemsLibraryDataModel().Items)
            {
                if (item is ResourcesItem resourcesItem)
                {
                    _resourcesItemList.Add(resourcesItem);
                }

                if (item is CraftedItem craftedItem)
                {
                    _craftedItemList.Add(craftedItem);
                }
            }
            
            await UniTask.CompletedTask;
        }

        #endregion
    }
}
