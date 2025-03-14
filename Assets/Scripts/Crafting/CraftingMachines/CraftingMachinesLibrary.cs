using UnityEngine;

namespace AF_Interview.Crafting
{
    [CreateAssetMenu(fileName = "CraftingMachinesLibrary", menuName = "Data/Crafting/CraftingMachinesLibrary")]
    public class CraftingMachinesLibrary : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField] private CraftingMachinesLibraryDataModel _dataModel;

        #endregion

        #region Properties

        public CraftingMachinesLibraryDataModel GetDataModel() => _dataModel;
        
        #endregion
    }
}
