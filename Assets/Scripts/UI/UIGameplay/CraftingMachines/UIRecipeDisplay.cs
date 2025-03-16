using System;
using AF_Interview.Crafting;
using AF_Interview.Systems;
using AF_Interview.Utilities;
using MessagePipe;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace AF_Interview.UI.UIGameplay
{
    public class UIRecipeDisplay : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<UIRecipeDisplay>
        {
        }

        #region Serialized Fields

        [SerializeField] private Button _recipeButton;
        [SerializeField] private TextMeshProUGUI _recipeNameText;

        [Header("Recipe slots")]
        [SerializeField] private UIInventorySlot _recipeIngredientsPrefab;
        [SerializeField] private Transform _recipeIngredientsContainer;

        #endregion

        #region Injected Fields

        [Inject] private CraftingSystem _craftingSystem;
        [Inject] private ISubscriber<CraftingFinishedEvent> _craftingFinishedEventSubscriber;

        #endregion

        #region Non-serialized Fields

        private RecipeSO _recipeData;
        private IDisposable _eventsBagDisposable;

        #endregion

        #region Public Methods

        public void Prepare(RecipeSO recipeData)
        {
            _recipeData = recipeData;
            
            _recipeIngredientsContainer.DestroyAllChildren();
            _recipeNameText.text = recipeData.RecipeName;

            foreach (var ingredient in recipeData.Ingredients)
            {
                var ingredientSlot = Instantiate(_recipeIngredientsPrefab, _recipeIngredientsContainer);
                ingredientSlot.SetSlotOccupied(ingredient.Key.ItemIcon, ingredient.Value);
            }

            _recipeButton.interactable = _craftingSystem.HasCorrectIngredients(recipeData);
            _recipeButton.onClick.AddListener(() => _craftingSystem.TryStartCrafting(recipeData));

            SubscribeToEvents();
        }

        #endregion

        #region Private Methods

        private void SubscribeToEvents()
        {
            var bag = DisposableBag.CreateBuilder();
            _craftingFinishedEventSubscriber.Subscribe(e => OnCraftingFinished()).AddTo(bag);
            
            _eventsBagDisposable = bag.Build();
        }

        private void OnDestroy()
        {
            _eventsBagDisposable?.Dispose();
        }
        
        private void OnCraftingFinished()
        {
            _recipeButton.interactable = _craftingSystem.HasCorrectIngredients(_recipeData);
        }

        #endregion
    }
}
