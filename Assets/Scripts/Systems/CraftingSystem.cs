using System;
using System.Collections.Generic;
using AF_Interview.Crafting;
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

        [Inject] private ICraftingService _craftingService;

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
            container.Bind<ICraftingService>()
                .To<CraftingService>()
                .AsSingle();
        }

        public override async UniTask Init()
        {
            PrepareStartCraftingElements();
            
            IsReady = true;
            await UniTask.CompletedTask;
        }

        #endregion

        #region Public Methods

        public List<CraftingMachine> GetCraftingMachines() => _craftingService.GetCraftingMachines();
        public List<Recipe> GetRecipes() => _craftingService.GetRecipes();

        #endregion

        #region Private Methods

        private void PrepareStartCraftingElements()
        {
            _craftingService.Init(GetStartedCraftingMachines(), GetStartedRecipes());
        }

        private List<CraftingMachine> GetStartedCraftingMachines()
        {
            List<CraftingMachine> initialCraftingMachines = new();

            foreach (var startedQuest in _craftingMachinesLibrary.GetDataModel().InitialCraftingMachines)
            {
                CraftingMachine craftingMachine = new CraftingMachine(startedQuest.CraftingMachineData, true);
                initialCraftingMachines.Add(craftingMachine);
            }
            
            return initialCraftingMachines;
        }

        private List<Recipe> GetStartedRecipes()
        {
            List<Recipe> initialRecipes = new();

            // by default unlocked all recipes, but we can of course prepare started recipe list
            foreach (var recipeSO in _recipesLibrary.GetDataModel().Recipes)
            {
                Recipe recipe = new Recipe(recipeSO);
                initialRecipes.Add(recipe);
            }

            return initialRecipes;
        }

        #endregion
    }
}
