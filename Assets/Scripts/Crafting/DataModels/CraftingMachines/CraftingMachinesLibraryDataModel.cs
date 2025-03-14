using System;
using System.Collections.Generic;
using UnityEngine;

namespace AF_Interview.Crafting
{
    [Serializable]
    public class CraftingMachinesLibraryDataModel
    {
        #region Serialized Fields

        [SerializeField] protected List<CraftingMachine> _craftingMachines = new();

        #endregion

        #region Properties

        public List<CraftingMachine> CraftingMachines { get => _craftingMachines; set => _craftingMachines = value; }

        #endregion
    }
}
