using System;
using System.Collections.Generic;
using UnityEngine;

namespace AF_Interview.Crafting
{
    [Serializable]
    public class CraftingMachinesLibraryDataModel
    {
        #region Serialized Fields

        [SerializeField] protected List<CraftingMachineSO> _craftingMachines = new();
        [SerializeField] protected List<InitialCraftingMachineDataModel> _initialCraftingMachines = new();

        #endregion

        #region Properties

        public List<CraftingMachineSO> CraftingMachines { get => _craftingMachines; set => _craftingMachines = value; }
        public List<InitialCraftingMachineDataModel> InitialCraftingMachines { get => _initialCraftingMachines; set => _initialCraftingMachines = value; }

        #endregion
    }
}
