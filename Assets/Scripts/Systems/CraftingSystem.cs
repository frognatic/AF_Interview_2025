using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AF_Interview.Crafting;
using AF_Interview.Quests;
using AF_Interview.Utilities;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using Zenject;

namespace AF_Interview.Systems
{
    public class CraftingSystem : SystemBase
    {
        #region Serialized Fields

        [SerializeField] private CraftingMachinesLibrary _craftingMachinesLibrary;
        [SerializeField] private RecipesLibrary _recipesLibrary;

        #endregion
        
        #region Injected Fields
        
        [Inject] private readonly IPublisher<CraftingStartedEvent> _craftingStartedEventPublisher;
        [Inject] private readonly IPublisher<CraftingProgressUpdatedEvent> _craftingProgressUpdatedEventPublisher;
        [Inject] private readonly IPublisher<CraftingFinishedEvent> _craftingFinishedEventPublisher;
        [Inject] private readonly IPublisher<UnlockedCraftingMachineEvent> _unlockedCraftingMachineEventPublisher;
        
        [Inject] private readonly ISubscriber<QuestCompletedEvent> _questCompletedEventSubscriber;

        [Inject] private readonly RecipesFactoryProvider _recipesFactoryProvider;
        [Inject] private readonly CraftingMachinesFactoryProvider _craftingMachinesFactoryProvider;
        [Inject] private readonly ItemSystem _itemSystem;
        [Inject] private readonly QuestsSystem _questsSystem;
        [Inject] private readonly BonusSystem _bonusSystem;

        #endregion
        
        #region Non-Serialized Fields

        private readonly List<CraftingMachine> _craftingMachines = new List<CraftingMachine>();
        private readonly List<Recipe> _recipes = new List<Recipe>();
        
        private Dictionary<CraftingMachine, IEnumerator> _craftingProcessesDictionary = new Dictionary<CraftingMachine, IEnumerator>();

        #endregion
        
        #region Properties

        public List<CraftingMachine> CraftingMachines => _craftingMachines;
        private IDisposable _eventsBagDisposable;

        #endregion
        
        #region Override Methods

        public override Type[] BindingContractTypes => new Type[]
        {
            typeof(CraftingSystem)
        };
        public override void Construct()
        {

        }
        public override void InstallBindings(DiContainer container, MessagePipeOptions messagePipeOptions)
        {
            container.BindMessageBroker<CraftingStartedEvent>(messagePipeOptions);
            container.BindMessageBroker<CraftingProgressUpdatedEvent>(messagePipeOptions);
            container.BindMessageBroker<CraftingFinishedEvent>(messagePipeOptions);
            container.BindMessageBroker<UnlockedCraftingMachineEvent>(messagePipeOptions);
            
            container.Bind<CraftingMachinesFactoryProvider>()
                .AsSingle();
            container.Bind<RecipesFactoryProvider>()
                .AsSingle();
        }

        public override async UniTask Init()
        {
            PrepareStartCraftingElements();
            
            var bag = DisposableBag.CreateBuilder();
            _questCompletedEventSubscriber.Subscribe(e => TryUnlockCraftingMachines(e.UserQuest.QuestData.CraftingMachinesToUnlock)).AddTo(bag);
            
            _eventsBagDisposable = bag.Build();
            
            IsReady = true;
            await UniTask.CompletedTask;
        }
        
        public override async UniTask DeInit()
        {
            _eventsBagDisposable?.Dispose();
            
            IsReady = false;
            await UniTask.CompletedTask;
        }

        #endregion

        #region Public Methods
        
        public void TryStartCrafting(Recipe recipe)
        {
            var craftingMachine = _craftingMachines.Find(x => x.CraftingMachineData.AvailableRecipes.Contains(recipe.RecipeData));
            
            if (CanStartCraftingProcess(craftingMachine, recipe))
            {
                StartCrafting(craftingMachine, recipe);
            }
        }

        public void TryStartCrafting(RecipeSO recipeData)
        {
            var recipe = _recipes.Find(x => x.RecipeData.RecipeName == recipeData.RecipeName);

            if (recipe != null)
            {
                TryStartCrafting(recipe);
            }
        }
        
        public bool HasCorrectIngredients(RecipeSO recipeData)
        {
            foreach (var ingredient in recipeData.Ingredients)
            {
                if (!_itemSystem.HasRequiredItemAmount(ingredient.Key, ingredient.Value))
                {
                    return false;
                }
            }

            return true;
        }
        
        #endregion

        #region Private Methods

        private void PrepareStartCraftingElements()
        {
            foreach (var craftingMachineSO in _craftingMachinesLibrary.CraftingMachines)
            {
                bool isMachineUnlockedOnStart = _craftingMachinesLibrary.InitialCraftingMachines.Contains(craftingMachineSO);
                var craftingMachine = _craftingMachinesFactoryProvider.CreateCraftingMachine(craftingMachineSO, isMachineUnlockedOnStart);
                _craftingMachines.Add(craftingMachine);
            }

            foreach (var recipeSO in _recipesLibrary.Recipes)
            {
                var recipe = _recipesFactoryProvider.CreateRecipe(recipeSO);
                _recipes.Add(recipe);
            }
        }
        
        private bool CanStartCraftingProcess(CraftingMachine craftingMachine, Recipe recipe)
        {
            var hasCorrectIngredients = HasCorrectIngredients(recipe.RecipeData);
            var isCraftingMachineNotStarted = !_craftingProcessesDictionary.ContainsKey(craftingMachine);
            
            return hasCorrectIngredients && isCraftingMachineNotStarted;
        }
        
        private void StartCrafting(CraftingMachine craftingMachine, Recipe recipe)
        {
            RemoveCraftingIngredients(recipe);
            _craftingStartedEventPublisher.Publish(new () { CraftingMachine = craftingMachine, Recipe = recipe});
            
            var craftingTime = recipe.RecipeData.CraftingTimeInSeconds - _bonusSystem.GetCraftingTimeReduceBonus();
            if (craftingTime > 0)
            {
                StartCraftingProcess(craftingMachine, recipe, craftingTime);
            }
            else
            {
                FinishCrafting(craftingMachine, recipe);
            }
        }

        private void StartCraftingProcess(CraftingMachine craftingMachine, Recipe recipe, int craftingTime)
        {
            IEnumerator craftingCoroutine = CraftProcess(craftingMachine, recipe, craftingTime, () => FinishCrafting(craftingMachine, recipe));
            _craftingProcessesDictionary.Add(craftingMachine, craftingCoroutine);
                    
            StartCoroutine(craftingCoroutine);
        }

        private void RemoveCraftingIngredients(Recipe recipe)
        {
            foreach (var ingredientToRemove in recipe.RecipeData.Ingredients)
            {
                _itemSystem.RemoveItem(ingredientToRemove.Key, ingredientToRemove.Value);
            }
        }
        
        private IEnumerator CraftProcess(CraftingMachine craftingMachine, Recipe recipe, float duration, Action finishCallback)
        {
            float elapsedTime = 0;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                
                _craftingProgressUpdatedEventPublisher.Publish(new CraftingProgressUpdatedEvent { Recipe = recipe, CraftingMachine = craftingMachine, CraftingProgressTime = elapsedTime / duration });
                
                yield return null;
            }

            finishCallback?.Invoke();
        }
        
        private void FinishCrafting(CraftingMachine craftingMachine, Recipe recipe)
        {
            bool isCraftingSuccess = TryAddCraftingResults(recipe);
            
            CraftingResult craftingResult = isCraftingSuccess ? CraftingResult.Success : CraftingResult.Failure;
            _craftingFinishedEventPublisher.Publish(new CraftingFinishedEvent { CraftingMachine = craftingMachine, Recipe = recipe, CraftingResult = craftingResult });
            
            // remove coroutines
            _craftingProcessesDictionary.Remove(craftingMachine);
        }

        private bool TryAddCraftingResults(Recipe recipe)
        {
            var craftingSuccessRate = recipe.RecipeData.CraftingSuccessRateInPercent + _bonusSystem.GetCraftingSuccessRateBonus();
            var isCraftingSuccessful = RandUtilities.CanProceed(craftingSuccessRate);

            if (!isCraftingSuccessful)
            {
                return false;
            }
            
            foreach (var result in recipe.RecipeData.CraftingResults)
            {
                _itemSystem.AddItem(result.Key, result.Value);
            }
            
            return true;
        }

        private void TryUnlockCraftingMachines(List<CraftingMachineSO> craftingMachinesData)
        {
            var notAvailableCraftingMachines = GetNotAvailableCraftingMachines();

            var craftingMachineSOSet = new HashSet<CraftingMachineSO>(craftingMachinesData);
            List<CraftingMachine> unlockedMachines = new();

            foreach (var craftingMachine in notAvailableCraftingMachines)
            {
                if (craftingMachineSOSet.Contains(craftingMachine.CraftingMachineData))
                {
                    craftingMachine.IsUnlocked = true;
                    unlockedMachines.Add(craftingMachine);
                }
            }

            foreach (var machine in unlockedMachines)
            {
                _unlockedCraftingMachineEventPublisher.Publish(new UnlockedCraftingMachineEvent { CraftingMachine = machine });
            }
        }

        private List<CraftingMachine> GetNotAvailableCraftingMachines()
        {
            return _craftingMachines.Where(x => !x.IsUnlocked).ToList();
        }
        
        #endregion
    }
}
