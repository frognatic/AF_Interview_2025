namespace AF_Interview.Crafting
{
    public class CraftingMachinesFactory : ICraftingMachinesFactory
    {
        public CraftingMachine CreateCraftingMachine(CraftingMachineSO data, bool isUnlocked)
        {
            return new CraftingMachine(data, isUnlocked);
        }
    }
    
    public interface ICraftingMachinesFactory
    {
        CraftingMachine CreateCraftingMachine(CraftingMachineSO data, bool isUnlocked);
    }
}
