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

        #endregion

        #region Properties

        public List<CraftingMachineSO> CraftingMachines { get => _craftingMachines; set => _craftingMachines = value; }

        #endregion
    }
}
