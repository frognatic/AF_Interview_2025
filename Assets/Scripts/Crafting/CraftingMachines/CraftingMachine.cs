using System;

namespace AF_Interview.Crafting
{
    [Serializable]
    public class CraftingMachine
    {
        public CraftingMachineSO CraftingMachineData { get; set; }
        public bool IsUnlocked { get; set; }

        public CraftingMachine(CraftingMachineSO craftingMachineData, bool isUnlocked = false)
        {
            CraftingMachineData = craftingMachineData;
            IsUnlocked = isUnlocked;
        }
    }
}
