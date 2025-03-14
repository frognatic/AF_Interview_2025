using System;
using AF_Interview.Items;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace AF_Interview.Crafting
{
    [Serializable]
    public class RecipeItemDataModel
    {
        #region Serialized Fields

        [SerializeField] protected SerializedDictionary<ItemBaseSO, int> _ingredients;
        [SerializeField] protected SerializedDictionary<ItemBaseSO, int> _craftingResults;
        [SerializeField] protected int _craftingTimeInSecondsInSeconds;
        [Tooltip("Success rate in percent (range - 0 - 100)")]
        [Range(0, 100)]
        [SerializeField] protected int _craftingSuccessRateInPercent = 100;
        [SerializeField] protected CraftingMachineSO _requiredRequiredCraftingMachineSo;

        #endregion
        
        #region Properties
        
        public SerializedDictionary<ItemBaseSO, int> Ingredients { get => _ingredients; set => _ingredients = value; }
        public SerializedDictionary<ItemBaseSO, int> CraftingResults { get => _craftingResults; set => _craftingResults = value; }
        public int CraftingTimeInSeconds { get => _craftingTimeInSecondsInSeconds; set => _craftingTimeInSecondsInSeconds = value; }
        public int CraftingSuccessRateInPercent { get => _craftingSuccessRateInPercent; set => _craftingSuccessRateInPercent = value; }
        public CraftingMachineSO RequiredCraftingMachineSo { get => _requiredRequiredCraftingMachineSo; set => _requiredRequiredCraftingMachineSo = value; }
        
        #endregion
    }
}
