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

        [Inject] private RecipesFactoryProvider _recipesFactoryProvider;
        [Inject] private CraftingMachinesFactoryProvider _craftingMachinesFactoryProvider;

        #endregion
        
        #region Non-Serialized Fields

        private readonly List<CraftingMachine> _craftingMachines = new List<CraftingMachine>();
        private readonly List<Recipe> _recipes = new List<Recipe>();

        #endregion
        
        #region Properties

        public List<CraftingMachine> CraftingMachines => _craftingMachines;
        public List<Recipe> Recipes => _recipes;

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
            container.Bind<CraftingMachinesFactoryProvider>()
                .AsSingle();
            container.Bind<RecipesFactoryProvider>()
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

        #endregion
    }
}
