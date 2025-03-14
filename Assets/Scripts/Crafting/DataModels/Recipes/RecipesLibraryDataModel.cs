using System;
using System.Collections.Generic;
using UnityEngine;

namespace AF_Interview.Crafting
{
    [Serializable]
    public class RecipesLibraryDataModel
    {
        #region Serialized Fields

        [SerializeField] protected List<RecipeSO> _recipes = new();

        #endregion

        #region Properties

        public List<RecipeSO> Recipes { get => _recipes; set => _recipes = value; }

        #endregion
    }
}
