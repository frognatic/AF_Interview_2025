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

        [SerializeField] protected SerializedDictionary<ItemBase, int> _ingredients;
        [SerializeField] protected SerializedDictionary<ItemBase, int> _craftingResults;
        [SerializeField] protected int _craftingTimeInSecondsInSeconds;
        [Tooltip("Success rate in percent (range - 0 - 100)")]
        [Range(0, 100)]
        [SerializeField] protected int _craftingSuccessRateInPercent = 100;
        [SerializeField] protected CraftingMachine _requiredRequiredCraftingMachine;

        #endregion
        
        #region Properties
        
        public SerializedDictionary<ItemBase, int> Ingredients { get => _ingredients; set => _ingredients = value; }
        public SerializedDictionary<ItemBase, int> CraftingResults { get => _craftingResults; set => _craftingResults = value; }
        public int CraftingTimeInSeconds { get => _craftingTimeInSecondsInSeconds; set => _craftingTimeInSecondsInSeconds = value; }
        public int CraftingSuccessRateInPercent { get => _craftingSuccessRateInPercent; set => _craftingSuccessRateInPercent = value; }
        public CraftingMachine RequiredCraftingMachine { get => _requiredRequiredCraftingMachine; set => _requiredRequiredCraftingMachine = value; }
        
        #endregion
    }
}
