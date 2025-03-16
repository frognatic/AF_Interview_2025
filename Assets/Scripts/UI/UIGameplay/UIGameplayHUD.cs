using System;
using AF_Interview.Crafting;
using AF_Interview.Quests;
using AF_Interview.Systems;
using AF_Interview.Utilities;
using MessagePipe;
using TMPro;
using UnityEngine;
using Zenject;

namespace AF_Interview.UI.UIGameplay
{
    public class UIGameplayHUDDataModel
    {
        public UIInventoryPanel _inventoryPanel;
    }
    
    public class UIGameplayHUD : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private TextMeshProUGUI _craftingSuccesRateBonusText;
        [SerializeField] private TextMeshProUGUI _craftingTimeBonusText;
        
        [SerializeField] private UITextLabel _textLabelPrefab;
        [SerializeField] private Transform _inventoryContent;
        [SerializeField] private Transform _forgeContent;
        [SerializeField] private Transform _questsContent;
        
        [SerializeField] private UIInventoryPanel _inventoryPanel;

        #endregion

        #region Injected Fields

        [Inject] private readonly ItemSystem _itemSystem;
        [Inject] private readonly QuestsSystem _questsSystem;
        [Inject] private readonly CraftingSystem _craftingSystem;
        [Inject] private readonly BonusSystem _bonusSystem;
        
        [Inject] private readonly ISubscriber<QuestProgressUpdateEvent> _questProgressUpdateEventSubscriber;
        [Inject] private readonly ISubscriber<QuestCompletedEvent> _questCompletedEventSubscriber;
        [Inject] private readonly ISubscriber<UnlockedCraftingMachineEvent> _unlockedCraftingMachineEventSubscriber;
        [Inject] private readonly ISubscriber<CraftingFinishedEvent> _craftingFinishedEventSubscriber;
        [Inject] private readonly ISubscriber<CraftingProgressUpdatedEvent> _craftingProgressUpdatedEventSubscriber;

        #endregion

        #region Non-Serialized Fields

        private IDisposable _eventsBagDisposable;

        #endregion

        #region Public Methods

        public void Prepare(UIGameplayHUDDataModel dataModel)
        {
            //_inventoryGrid.Prepare(dataModel.InventoryGridDataModel);
            
            SubscribeToEvents();
        }

        public void RefreshInventoryGrid()
        {
            _inventoryPanel.RefreshSlots();
        }

        #endregion
        
        #region Private Methods

        private void Start()
        {
            //SubscribeToEvents();
            
            //CreateInventoryContent();
            // CreateForgeContent();
            // CreateQuestsContent();
            
            // _craftingSuccesRateBonusText.text = $"Success Rate + {_bonusSystem.CraftingSuccessRateBonus}%";
            // _craftingTimeBonusText.text = $"Time Bonus: {_bonusSystem.CraftingTimeReduceBonus}s";
        }
        
        private void SubscribeToEvents()
        {
            var bag = DisposableBag.CreateBuilder();
            
            //_questProgressUpdateEventSubscriber.Subscribe(e => CreateQuestsContent()).AddTo(bag);
            //_questCompletedEventSubscriber.Subscribe(e => CreateQuestsContent()).AddTo(bag);
            
            //_unlockedCraftingMachineEventSubscriber.Subscribe(e => CreateForgeContent()).AddTo(bag);
            
            _craftingFinishedEventSubscriber.Subscribe(e => OnCraftingFinished(e.CraftingResult, e.Recipe)).AddTo(bag);
            //_craftingProgressUpdatedEventSubscriber.Subscribe(e => OnCraftingProgressUpdated(e.CraftingMachine, e.Recipe, e.ElapsedTime)).AddTo(bag);
            
            _eventsBagDisposable = bag.Build();
        }

        private void OnCraftingFinished(CraftingResult craftingResult, Recipe recipe)
        {
            
        }

        private void CreateInventoryContent()
        {
            _inventoryContent.DestroyAllChildren();
            foreach (var item in _itemSystem.GetAllAvailableItems())
            {
                var itemDisplay = Instantiate(_textLabelPrefab, _inventoryContent);
            
                string itemDisplayText = $"{item.ItemData.ItemName} || {item.Amount}";
                itemDisplay.SetText(itemDisplayText);
            }
        }

        private void CreateQuestsContent()
        {
            _questsContent.DestroyAllChildren();
            foreach (var quest in _questsSystem.Quests)
            {
                var questDisplay = Instantiate(_textLabelPrefab, _questsContent);

                string finishedText = "FINISHED";
                string questDisplayText = $"{quest.QuestData.QuestName} || {quest.Progress[0].CurrentValue}/{quest.Progress[0].EndValue}";
                
                questDisplay.SetText(quest.IsFinished ? finishedText : questDisplayText);
            }
        }

        private void CreateForgeContent()
        {
            _forgeContent.DestroyAllChildren();
            foreach (var craftingMachine in _craftingSystem.GetAvailableCraftingMachines())
            {
                var craftingMachineDisplay = Instantiate(_textLabelPrefab, _forgeContent);
            
                string craftingMachineText = $"{craftingMachine.CraftingMachineData.MachineName}";
                craftingMachineDisplay.SetText(craftingMachineText);
            }
        }

        private void OnCraftingProgressUpdated(CraftingMachine craftingMachine, Recipe recipe, float elapsedTime)
        {
            Debug.LogWarning($"Working Machine: {craftingMachine.CraftingMachineData.MachineName} // elapsed time: {elapsedTime}");
        }
        
        private void OnDestroy()
        {
            _eventsBagDisposable?.Dispose();
        }

        #endregion
    }
}
