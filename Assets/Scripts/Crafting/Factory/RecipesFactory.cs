namespace AF_Interview.Crafting
{
    public class RecipesFactory : IRecipesFactory
    {
        public Recipe CreateRecipe(RecipeSO data)
        {
            return new Recipe(data);
        }
    }
    
    public interface IRecipesFactory
    {
        Recipe CreateRecipe(RecipeSO data);
    }
}
