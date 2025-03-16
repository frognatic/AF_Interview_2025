using System;
using System.Collections.Generic;
using AF_Interview.Crafting;
using AF_Interview.Utilities;
using MessagePipe;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace AF_Interview.UI.UIGameplay
{
    public class UICraftingMachineDisplay : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<UICraftingMachineDisplay>
        {
        }

        #region Serialized Fields

        [Header("Crafting Machine")]
        [SerializeField] private Image _craftingMachineImage;
        [SerializeField] private TextMeshProUGUI _craftingMachineName;

        [Header("Panels")]
        [SerializeField] private GameObject _craftingPanel;
        [SerializeField] private GameObject _lockedPanel;
        [SerializeField] private GameObject _craftingProgressPanel;

        [Header("Recipes")]
        [SerializeField] private Transform _recipeDisplayContainer;
        
        [Header("CraftingProgress")]
        [SerializeField] private Slider _craftingProgressSlider;

        #endregion

        #region Injected Fields

        [Inject] private UIRecipeDisplay.Factory _recipeDisplayFactory;
        [Inject] private ISubscriber<CraftingStartedEvent> _craftingStartedEventSubscriber;
        [Inject] private ISubscriber<CraftingFinishedEvent> _craftingFinishedEventSubscriber;
        [Inject] private ISubscriber<CraftingProgressUpdatedEvent> _craftingProgressUpdatedEventSubscriber;

        #endregion

        #region Properties

        public CraftingMachine CraftingMachine => _craftingMachine;

        #endregion

        #region Non-Serialized Fields

        private CraftingMachine _craftingMachine;
        private List<UIRecipeDisplay> _recipeDisplayList = new List<UIRecipeDisplay>();
        private IDisposable _eventsBagDisposable;

        #endregion

        #region Public Methods

        public void Prepare(CraftingMachine craftingMachine)
        {
            _craftingMachine = craftingMachine;

            _craftingMachineImage.sprite = craftingMachine.CraftingMachineData.MachineIcon;
            _craftingMachineName.text = craftingMachine.CraftingMachineData.MachineName;

            PrepareCraftingRecipes(craftingMachine.CraftingMachineData.AvailableRecipes);
            UpdateVisibility(craftingMachine.IsUnlocked);
        }

        public void UpdateVisibility(bool isUnlocked)
        {
            _craftingPanel.SetActive(isUnlocked);
            _lockedPanel.SetActive(!isUnlocked);
        }

        #endregion

        #region Private Methods

        private void PrepareCraftingRecipes(List<RecipeSO> recipesData)
        {
            _recipeDisplayList.Clear();
            _recipeDisplayContainer.DestroyAllChildren();

            foreach (var recipe in recipesData)
            {
                UIRecipeDisplay recipeDisplay = _recipeDisplayFactory.Create();
                recipeDisplay.transform.SetParent(_recipeDisplayContainer, false);

                recipeDisplay.Prepare(recipe);
                _recipeDisplayList.Add(recipeDisplay);
            }

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            var bag = DisposableBag.CreateBuilder();
            
            _craftingStartedEventSubscriber.Subscribe(e => OnCraftingStarted(e.CraftingMachine, e.Recipe)).AddTo(bag);
            _craftingFinishedEventSubscriber.Subscribe(e => OnCraftingFinished(e.CraftingMachine)).AddTo(bag);
            _craftingProgressUpdatedEventSubscriber.Subscribe(e => 
                OnCraftingProgressUpdated(e.CraftingMachine, e.CraftingProgressTime)).AddTo(bag);

            _eventsBagDisposable = bag.Build();
        }

        private void OnDestroy()
        {
            _eventsBagDisposable?.Dispose();
        }

        private void OnCraftingStarted(CraftingMachine craftingMachine, Recipe recipe)
        {
            if (craftingMachine != _craftingMachine)
            {
                return;
            }
        }

        private void OnCraftingFinished(CraftingMachine craftingMachine)
        {
            if (craftingMachine != _craftingMachine)
            {
                return;
            }
            
            _craftingProgressPanel.SetActive(false);
        }

        private void OnCraftingProgressUpdated(CraftingMachine craftingMachine, float craftingProgress)
        {
            if (craftingMachine != _craftingMachine)
            {
                return;
            }
            
            _craftingProgressPanel.SetActive(true);

            _craftingProgressSlider.value = craftingProgress;
        }

        #endregion
    }
}
