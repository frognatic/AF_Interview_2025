using UnityEngine;

namespace AF_Interview.Crafting
{
    [CreateAssetMenu(fileName = "RecipesLibrary", menuName = "Data/Crafting/RecipesLibrary")]
    public class RecipesLibrary : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField] private RecipesLibraryDataModel _dataModel;

        #endregion

        #region Properties

        public RecipesLibraryDataModel GetDataModel() => _dataModel;
        
        #endregion
    }
}
