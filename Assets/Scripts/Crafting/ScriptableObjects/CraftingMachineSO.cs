using System.Collections.Generic;
using UnityEngine;

namespace AF_Interview.Crafting
{
    [CreateAssetMenu(fileName = "CraftingMachine", menuName = "Data/Crafting/CraftingMachine")]
    public class CraftingMachineSO : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField] protected string _machineId;
        [SerializeField] protected string _machineName;
        [SerializeField] protected string _machineDescription;
        [SerializeField] protected List<RecipeSO> _availableRecipes;
        [SerializeField] protected Sprite _machineIcon;

        #endregion
        
        #region Properties
        
        public string MachineId { get => _machineId; set => _machineId = value; }
        public string MachineName { get => _machineName; set => _machineName = value; }
        public string MachineDescription { get => _machineDescription; set => _machineDescription = value; }
        public List<RecipeSO> AvailableRecipes { get => _availableRecipes; set => _availableRecipes = value; }
        public Sprite MachineIcon { get => _machineIcon; set => _machineIcon = value; }
        
        #endregion
    }
}
