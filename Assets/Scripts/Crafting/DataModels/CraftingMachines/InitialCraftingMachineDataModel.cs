using System;
using UnityEngine;

namespace AF_Interview.Crafting
{
    [Serializable]
    public class InitialCraftingMachineDataModel
    {
        #region Serialized Fields

        [SerializeField] protected CraftingMachineSO _craftingMachineData;

        #endregion

        #region Properties

        public CraftingMachineSO CraftingMachineData { get => _craftingMachineData; set => _craftingMachineData = value; }

        #endregion
    }
}
