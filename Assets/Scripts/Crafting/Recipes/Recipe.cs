using System;

namespace AF_Interview.Crafting
{
    [Serializable]
    public class Recipe
    {
        public RecipeSO RecipeData { get; set; }
        
        public Recipe(RecipeSO recipeData)
        {
            RecipeData = recipeData;
        }
    }
}
