using System.Collections.Generic;
using UnityEngine;

namespace AF_Interview.Crafting
{
    [CreateAssetMenu(fileName = "RecipesLibrary", menuName = "Data/Crafting/RecipesLibrary")]
    public class RecipesLibrary : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField] protected List<RecipeSO> _recipes = new();

        #endregion

        #region Properties

        public List<RecipeSO> Recipes { get => _recipes; set => _recipes = value; }

        #endregion
    }
}
