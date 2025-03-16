using System;
using System.Collections.Generic;
using AF_Interview.Crafting;
using AF_Interview.Systems;
using AF_Interview.Utilities;
using MessagePipe;
using UnityEngine;
using Zenject;

namespace AF_Interview.UI.UIGameplay
{
    public class UICraftingMachinesPanelDataModel : DataModel
    {
        public List<CraftingMachine> CraftingMachines;
    }
    
    public class UICraftingMachinesPanel : UIBasePanel
    {
        #region Serialized Fields

        [SerializeField] private  UICraftingMachineDisplay _craftingMachineDisplayPrefab;
        [SerializeField] private Transform _craftingMachineContainer;

        #endregion

        #region Injected Fields

        [Inject] private CraftingSystem _craftingSystem;
        [Inject] private ISubscriber<UnlockedCraftingMachineEvent> _unlockedCraftingMachineEventSubscriber;
        [Inject] private UICraftingMachineDisplay.Factory _craftingMachineDisplayFactory;

        #endregion

        #region Non-Serialized Fields

        private List<UICraftingMachineDisplay> _craftingMachineDisplays = new List<UICraftingMachineDisplay>();
        private IDisposable _eventsBagDisposable;

        #endregion
        
        #region Properties
        
        protected new UICraftingMachinesPanelDataModel DataModel => (UICraftingMachinesPanelDataModel)base.DataModel;
        
        #endregion

        #region Public Methods
        
        public override void Prepare(DataModel dataModel)
        {
            base.Prepare(dataModel);
            
            _craftingMachineContainer.DestroyAllChildren();
            
            foreach (var craftingMachine in DataModel.CraftingMachines)
            {
                UICraftingMachineDisplay craftingMachineDisplay = _craftingMachineDisplayFactory.Create();
                craftingMachineDisplay.transform.SetParent(_craftingMachineContainer, false);
                
                craftingMachineDisplay.Prepare(craftingMachine);
                _craftingMachineDisplays.Add(craftingMachineDisplay);
            }

            SubscribeEvents();
        }
        
        #endregion

        #region Private Methods

        private void SubscribeEvents()
        {
            var bag = DisposableBag.CreateBuilder();
            _unlockedCraftingMachineEventSubscriber.Subscribe(e => OnCraftingMachineUnlocked(e.CraftingMachine)).AddTo(bag);
            
            _eventsBagDisposable = bag.Build();
        }

        private void OnDisable()
        {
            _eventsBagDisposable?.Dispose();
        }
        
        private void UpdateCraftingMachineVisibility(CraftingMachine craftingMachine)
        {
            var craftingMachineDisplay = _craftingMachineDisplays.Find(x => x.CraftingMachine == craftingMachine);

            if (craftingMachineDisplay != null)
            {
                craftingMachineDisplay.UpdateVisibility(craftingMachine.IsUnlocked);
            }
        }
        
        // events responses
        private void OnCraftingMachineUnlocked(CraftingMachine craftingMachine)
        {
            UpdateCraftingMachineVisibility(craftingMachine);
        }

        #endregion
    }
}
