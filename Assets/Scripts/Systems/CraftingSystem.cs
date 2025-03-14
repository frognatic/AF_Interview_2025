using System;
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

        }

        public override async UniTask Init()
        {
            IsReady = true;
            await UniTask.CompletedTask;
        }

        #endregion
    }
}
