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
        
        public string MachineId => _machineId;
        public string MachineName => _machineName;
        public string MachineDescription => _machineDescription;
        public List<RecipeSO> AvailableRecipes => _availableRecipes;
        public Sprite MachineIcon => _machineIcon;

        #endregion
    }
}
