using System.Collections.Generic;
using Zenject;

namespace AF_Interview.Crafting
{
    public interface ICraftingService
    {
        List<CraftingMachine> GetCraftingMachines();
        List<Recipe> GetRecipes();
        void Init(List<CraftingMachine> craftingMachines, List<Recipe> recipes);
    }
    
    public class CraftingService : ICraftingService
    {
        private List<CraftingMachine> _craftingMachines = new List<CraftingMachine>();
        private List<Recipe> _recipes = new List<Recipe>();

        [Inject]
        public CraftingService()
        {
        }
        
        public void Init(List<CraftingMachine> craftingMachines, List<Recipe> recipes)
        {
            _craftingMachines = craftingMachines;
            _recipes = recipes;
        }

        public List<CraftingMachine> GetCraftingMachines() => _craftingMachines;

        public List<Recipe> GetRecipes() => _recipes;
    }
}
