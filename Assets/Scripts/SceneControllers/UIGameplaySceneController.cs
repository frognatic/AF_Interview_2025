using System;
using AF_Interview.Crafting;
using AF_Interview.Quests;
using AF_Interview.Systems;
using AF_Interview.UI.UIGameplay;
using MessagePipe;
using UnityEngine;
using Zenject;

namespace AF_Interview.SceneControllers
{
    public class UIGameplaySceneController : BaseSceneController
    {
        #region Serialized Fields

        [Header("Main UI Reference")]
        [SerializeField] private UIInventoryPanel _inventoryPanel;
        [SerializeField] private UIQuestsPanel _questsPanel;
        [SerializeField] private UIBonusesPanel _bonusesPanel;
        [SerializeField] private UICraftingMachinesPanel _craftingMachinesPanel;

        #endregion
        
        #region Injected Fields

        [Inject] private readonly ItemSystem _itemSystem;
        [Inject] private readonly QuestsSystem _questsSystem;
        [Inject] private readonly CraftingSystem _craftingSystem;
        [Inject] private readonly BonusSystem _bonusSystem;
        
        [Inject] private readonly ISubscriber<CraftingStartedEvent> _craftingStartedEventSubscriber;
        [Inject] private readonly ISubscriber<CraftingFinishedEvent> _craftingFinishedEventSubscriber;
        [Inject] private readonly ISubscriber<QuestProgressUpdateEvent> _questProgressUpdateEventSubscriber;

        #endregion
        
        #region Non-Serialized Fields
        
        private IDisposable _eventsBagDisposable;
        
        // DataModels
        private UIInventoryPanelDataModel _inventoryPanelDataModel;
        private UIQuestsPanelDataModel _questsPanelDataModel;
        private UIBonusesPanelDataModel _bonusesPanelDataModel;
        private UICraftingMachinesPanelDataModel _craftingMachinesPanelDataModel;

        #endregion
        
        protected override void Start()
        {
            base.Start();

            PrepareInventoryPanel();
            PrepareQuestsPanel();
            PrepareBonusesPanel();
            PrepareCraftingMachinesPanel();

            SubscribeToEvents();
        }

        #region Private Methods

        private void SubscribeToEvents()
        {
            var bag = DisposableBag.CreateBuilder();

            _craftingStartedEventSubscriber.Subscribe(e => OnCraftingStarted(e.Recipe)).AddTo(bag);
            _craftingFinishedEventSubscriber.Subscribe(e => OnCraftingFinished(e.CraftingResult, e.Recipe)).AddTo(bag);
            _questProgressUpdateEventSubscriber.Subscribe(e => OnQuestProgress(e.Quest)).AddTo(bag);
            
            _eventsBagDisposable = bag.Build();
        }
        
        // UI Panels

        private void PrepareInventoryPanel()
        {
            _inventoryPanelDataModel ??= new UIInventoryPanelDataModel();
            _inventoryPanelDataModel.AvailableItemsList = _itemSystem.GetAllAvailableItems();

            _inventoryPanel.Prepare(_inventoryPanelDataModel);
        }

        private void PrepareQuestsPanel()
        {
            _questsPanelDataModel ??= new UIQuestsPanelDataModel();
            _questsPanelDataModel.Quest = _questsSystem.Quests;
            
            _questsPanel.Prepare(_questsPanelDataModel);
        }

        private void PrepareBonusesPanel()
        {
            _bonusesPanelDataModel ??= new UIBonusesPanelDataModel();
            _bonusesPanelDataModel.Bonuses = _bonusSystem.Bonuses;
            
            _bonusesPanel.Prepare(_bonusesPanelDataModel);
        }

        private void PrepareCraftingMachinesPanel()
        {
            _craftingMachinesPanelDataModel ??= new UICraftingMachinesPanelDataModel();
            _craftingMachinesPanelDataModel.CraftingMachines = _craftingSystem.CraftingMachines;
            
            _craftingMachinesPanel.Prepare(_craftingMachinesPanelDataModel);
        }
        
        // Events Responses

        private void OnCraftingStarted(Recipe recipe)
        {
            _inventoryPanelDataModel.AvailableItemsList = _itemSystem.GetAllAvailableItems();
            _inventoryPanel.RefreshSlots();
        }
        
        private void OnCraftingFinished(CraftingResult craftingResult, Recipe recipe)
        {
            _inventoryPanelDataModel.AvailableItemsList = _itemSystem.GetAllAvailableItems();
            _inventoryPanel.RefreshSlots();
        }

        private void OnQuestProgress(Quest questProgress)
        {
            _questsPanelDataModel.Quest = _questsSystem.Quests;
            _questsPanel.Prepare(_questsPanelDataModel);
        }
        
        // Others

        private void OnDestroy()
        {
            _eventsBagDisposable?.Dispose();
        }

        #endregion
    }
}
