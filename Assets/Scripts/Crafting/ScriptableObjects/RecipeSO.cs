using AF_Interview.Items;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace AF_Interview.Crafting
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "Data/Crafting/Recipe")]
    public class RecipeSO : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField] protected string _recipeName;
        [SerializeField] protected SerializedDictionary<ItemSO, int> _ingredients;
        [SerializeField] protected SerializedDictionary<ItemSO, int> _craftingResults;
        [SerializeField] protected int _craftingTimeInSeconds;
        [Tooltip("Success rate in percent (range - 0 - 100)")]
        [Range(0, 100)]
        [SerializeField] protected int _craftingSuccessRateInPercent = 100;

        #endregion
        
        #region Properties

        public string RecipeName => _recipeName;
        public SerializedDictionary<ItemSO, int> Ingredients => _ingredients;
        public SerializedDictionary<ItemSO, int> CraftingResults => _craftingResults;
        public int CraftingTimeInSeconds => _craftingTimeInSeconds;
        public int CraftingSuccessRateInPercent => _craftingSuccessRateInPercent;

        #endregion
    }
}
