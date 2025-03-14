using System;
using UnityEngine;

namespace AF_Interview.Items
{
    [Serializable]
    public class CraftedItemDataModel
    {
        #region Serialized Fields

        [SerializeField] protected int _machineId;
        [SerializeField] protected string _machineName;
        [SerializeField] protected string _machineDescription;

        #endregion

        #region Properties

        public int MachineId { get => _machineId; set => _machineId = value; }
        public string MachineName { get => _machineName; set => _machineName = value; }
        public string MachineDescription { get => _machineDescription; set => _machineDescription = value; }

        #endregion
    }
}
