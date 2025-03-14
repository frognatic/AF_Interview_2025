using System;
using UnityEngine;

namespace AF_Interview.Crafting
{
    [Serializable]
    public class CraftingMachineDataModel
    {
        #region Serialized Fields

        [SerializeField] private string _machineId;
        [SerializeField] private string _machineName;
        [SerializeField] private string _machineDescription;

        #endregion
        
        #region Properties
        
        public string MachineId { get => _machineId; set => _machineId = value; }
        public string MachineName { get => _machineName; set => _machineName = value; }
        public string MachineDescription { get => _machineDescription; set => _machineDescription = value; }
        
        #endregion
    }
}
