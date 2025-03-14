using UnityEngine;

namespace AF_Interview.Crafting
{
    [CreateAssetMenu(fileName = "CraftingMachine", menuName = "Data/Crafting/CraftingMachine")]
    public class CraftingMachineSO : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField] private CraftingMachineDataModel _dataModel;

        #endregion

        #region Properties

        public CraftingMachineDataModel GetDataModel() => _dataModel;
        
        #endregion
    }
}
