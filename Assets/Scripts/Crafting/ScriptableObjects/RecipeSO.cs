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
        [SerializeField] protected int _craftingTimeInSecondsInSeconds;
        [Tooltip("Success rate in percent (range - 0 - 100)")]
        [Range(0, 100)]
        [SerializeField] protected int _craftingSuccessRateInPercent = 100;

        #endregion
        
        #region Properties
        
        public string RecipeName {get => _recipeName; set => _recipeName = value; }
        public SerializedDictionary<ItemSO, int> Ingredients { get => _ingredients; set => _ingredients = value; }
        public SerializedDictionary<ItemSO, int> CraftingResults { get => _craftingResults; set => _craftingResults = value; }
        public int CraftingTimeInSeconds { get => _craftingTimeInSecondsInSeconds; set => _craftingTimeInSecondsInSeconds = value; }
        public int CraftingSuccessRateInPercent { get => _craftingSuccessRateInPercent; set => _craftingSuccessRateInPercent = value; }
        
        #endregion
    }
}
