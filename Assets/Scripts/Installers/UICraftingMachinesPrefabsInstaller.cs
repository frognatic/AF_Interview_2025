using AF_Interview.UI.UIGameplay;
using UnityEngine;
using Zenject;

namespace AF_Interview.Installers
{
    public class UICraftingMachinesPrefabsInstaller : MonoInstaller
    {
        #region Serialized Fields

        [SerializeField] private UICraftingMachineDisplay _craftingMachineDisplayPrefab;
        [SerializeField] private UIRecipeDisplay _recipeDisplayPrefab;

        #endregion

        #region Override Methods

        public override void InstallBindings()
        {
            Container.BindFactory<UICraftingMachineDisplay, UICraftingMachineDisplay.Factory>()
                .FromComponentInNewPrefab(_craftingMachineDisplayPrefab)
                .UnderTransformGroup("CraftingMachineDisplays")
                .AsTransient();
            
            Container.BindFactory<UIRecipeDisplay, UIRecipeDisplay.Factory>()
                .FromComponentInNewPrefab(_recipeDisplayPrefab)
                .UnderTransformGroup("RecipeDisplays")
                .AsTransient();
        }

        #endregion
    }
}
