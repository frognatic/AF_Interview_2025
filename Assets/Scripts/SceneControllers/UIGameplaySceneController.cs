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
    public class UIGameplaySceneController : MonoBehaviour
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
        
        #region Private Methods

        private void Start()
        {
            PrepareInventoryPanel();
            PrepareQuestsPanel();
            PrepareBonusesPanel();
            PrepareCraftingMachinesPanel();

            SubscribeToEvents();
        }
        
        private void SubscribeToEvents()
        {
            var bag = DisposableBag.CreateBuilder();

            _craftingStartedEventSubscriber.Subscribe(e => OnCraftingStarted()).AddTo(bag);
            _craftingFinishedEventSubscriber.Subscribe(e => OnCraftingFinished()).AddTo(bag);
            _questProgressUpdateEventSubscriber.Subscribe(e => OnQuestProgress()).AddTo(bag);
            
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
            _bonusesPanelDataModel.Bonuses = _bonusSystem.ActiveBonuses;
            
            _bonusesPanel.Prepare(_bonusesPanelDataModel);
        }

        private void PrepareCraftingMachinesPanel()
        {
            _craftingMachinesPanelDataModel ??= new UICraftingMachinesPanelDataModel();
            _craftingMachinesPanelDataModel.CraftingMachines = _craftingSystem.CraftingMachines;
            
            _craftingMachinesPanel.Prepare(_craftingMachinesPanelDataModel);
        }
        
        // Events Responses

        private void OnCraftingStarted()
        {
            _inventoryPanelDataModel.AvailableItemsList = _itemSystem.GetAllAvailableItems();
            _inventoryPanel.RefreshSlots();
        }
        
        private void OnCraftingFinished()
        {
            _inventoryPanelDataModel.AvailableItemsList = _itemSystem.GetAllAvailableItems();
            _inventoryPanel.RefreshSlots();
        }

        private void OnQuestProgress()
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
