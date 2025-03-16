using System;
using AF_Interview.Crafting;
using AF_Interview.Items;
using AF_Interview.Systems;
using MessagePipe;
using Zenject;

namespace AF_Interview.SceneControllers
{
    public class UIGameplaySceneController : BaseSceneController
    {
        [Inject] private readonly ItemSystem _itemSystem;
        [Inject] private readonly QuestsSystem _questsSystem;
        [Inject] private readonly CraftingSystem _craftingSystem;
        
        [Inject] private readonly ISubscriber<CraftingStartedEvent> _craftingStartedEventSubscriber;
        [Inject] private readonly ISubscriber<CraftingFinishedEvent> _craftingFinishedEventSubscriber;

        private IDisposable _eventsBagDisposable;
        
        protected override void Start()
        {
            base.Start();
            
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

        private void OnDestroy()
        {
            _eventsBagDisposable?.Dispose();
        }
    }
}
