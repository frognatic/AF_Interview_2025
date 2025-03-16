using System.Collections.Generic;
using UnityEngine;

namespace AF_Interview.Crafting
{
    [CreateAssetMenu(fileName = "CraftingMachinesLibrary", menuName = "Data/Crafting/CraftingMachinesLibrary")]
    public class CraftingMachinesLibrary : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField] protected List<CraftingMachineSO> _craftingMachines = new();
        [SerializeField] protected List<CraftingMachineSO> _initialCraftingMachines = new();

        #endregion

        #region Properties

        public List<CraftingMachineSO> CraftingMachines { get => _craftingMachines; set => _craftingMachines = value; }
        public List<CraftingMachineSO> InitialCraftingMachines { get => _initialCraftingMachines; set => _initialCraftingMachines = value; }

        #endregion
    }
}
