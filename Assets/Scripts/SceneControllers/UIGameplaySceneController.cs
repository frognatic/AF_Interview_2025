using System;
using AF_Interview.Crafting;
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
        [SerializeField] private UIGameplayHUD _uiGameplayHUD;
        [SerializeField] private UIInventoryGrid _inventoryGrid;

        #endregion
        
        #region Injected Fields

        [Inject] private readonly ItemSystem _itemSystem;
        [Inject] private readonly QuestsSystem _questsSystem;
        [Inject] private readonly CraftingSystem _craftingSystem;
        
        [Inject] private readonly ISubscriber<CraftingStartedEvent> _craftingStartedEventSubscriber;
        [Inject] private readonly ISubscriber<CraftingFinishedEvent> _craftingFinishedEventSubscriber;

        #endregion
        
        #region Non-Serialized Fields
        
        private IDisposable _eventsBagDisposable;
        
        // DataModels
        private UIGameplayHUDDataModel _uiGameplayHUDDataModel;
        private UIInventoryGridDataModel _inventoryGridDataModel;

        #endregion
        
        protected override void Start()
        {
            base.Start();

            OpenUIGameplayHUD();
            OpenInventoryGrid();

            SubscribeToEvents();

            // var bag = DisposableBag.CreateBuilder();
            //
            // _craftingStartedEventSubscriber.Subscribe(e => Debug.LogWarning($"CraftingStarted event received: {e.Recipe.RecipeData.RecipeName}")).AddTo(bag);
            // _craftingFinishedEventSubscriber.Subscribe(e => Debug.LogWarning($"CraftingFinished event received: {e.Recipe.RecipeData.RecipeName}")).AddTo(bag);
            //
            // _eventsBagDisposable = bag.Build();
            //
            // var items = _itemSystem.GetAllAvailableItems();
            // var quests = _questsSystem.Quests;
            // var machines = _craftingSystem.CraftingMachines;
            //
            // foreach (var item in items)
            // {
            //     if (item is BonusItem)
            //     {
            //         Debug.LogWarning($"{item.ItemData.ItemName} is a bonus item and amount is: {item.Amount}");
            //     }
            //     else
            //     {
            //         Debug.LogWarning($"{item.ItemData.ItemName} is an item and amount is: {item.Amount}");
            //     }
            // }
            //
            // foreach (var quest in quests)
            // {
            //     foreach (var progress in quest.Progress)
            //     {
            //         Debug.LogWarning($"Progress for quest: {quest.QuestData.QuestName} [{progress.CurrentValue}/{progress.EndValue}]");
            //     }
            // }
            //
            // foreach (var machine in _craftingSystem.CraftingMachines)
            // {
            //     Debug.LogWarning($"Machine: {machine.CraftingMachineData.MachineName} is unlocked: {machine.IsUnlocked}");
            // }
        }

        #region Private Methods

        private void SubscribeToEvents()
        {
            var bag = DisposableBag.CreateBuilder();
            
            _craftingStartedEventSubscriber.Subscribe(e => OnCraftingStarted(e.Recipe)).AddTo(bag);
            _craftingFinishedEventSubscriber.Subscribe(e => OnCraftingFinished(e.CraftingResult, e.Recipe)).AddTo(bag);
            
            _eventsBagDisposable = bag.Build();
        }
        
        // UI Panels
        private void OpenUIGameplayHUD()
        {
            _uiGameplayHUDDataModel ??= new UIGameplayHUDDataModel();
            
            // InventoryModel
            _uiGameplayHUDDataModel.InventoryGridDataModel ??= new UIInventoryGridDataModel();
            _uiGameplayHUDDataModel.InventoryGridDataModel.AvailableItemsList = _itemSystem.GetAllAvailableItems();
            
            _uiGameplayHUD.Prepare(_uiGameplayHUDDataModel);
        }

        private void OpenInventoryGrid()
        {
            _inventoryGridDataModel ??= new UIInventoryGridDataModel();
            _inventoryGridDataModel.AvailableItemsList = _itemSystem.GetAllAvailableItems();

            _inventoryGrid.Prepare(_inventoryGridDataModel);
        }
        
        // Events Responses

        private void OnCraftingFinished(CraftingResult craftingResult, Recipe recipe)
        {
            _inventoryGridDataModel.AvailableItemsList = _itemSystem.GetAllAvailableItems();
            _inventoryGrid.RefreshSlots();
        }

        private void OnCraftingStarted(Recipe recipe)
        {
            _inventoryGridDataModel.AvailableItemsList = _itemSystem.GetAllAvailableItems();
            _inventoryGrid.RefreshSlots();
        }
        
        // Others

        private void OnDestroy()
        {
            _eventsBagDisposable?.Dispose();
        }

        #endregion
    }
}
