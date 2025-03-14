using UnityEngine;

namespace AF_Interview.Crafting
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "Data/Crafting/Recipe")]
    public class RecipeSO : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField] private RecipeItemDataModel _dataModel;

        #endregion

        #region Properties

        public RecipeItemDataModel GetDataModel() => _dataModel;
        
        #endregion
    }
}
