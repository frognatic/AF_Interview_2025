using AF_Interview.Items.DataModels;
using UnityEngine;

namespace AF_Interview.Items
{
    public abstract class ItemBase : ScriptableObject, IItemBaseDataModel
    {
        #region Properties
        
        protected virtual ItemBaseDataModel DataModel { get; set; }

        public ItemBaseDataModel GetDataModel() => DataModel;

        #endregion
    }

    public interface IItemBaseDataModel
    {
        ItemBaseDataModel GetDataModel();
    }
}
